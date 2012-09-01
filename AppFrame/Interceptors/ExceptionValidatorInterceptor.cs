using AppFrame.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Castle.DynamicProxy;

namespace AppFrame.Interceptors
{
	/// <summary>
	/// An interceptor for exception-based validation.
	/// </summary>
	[System.Serializable]
	public class ExceptionValidatorInterceptor : InterceptorBase
	{
		readonly IValidator _validator;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExceptionValidatorInterceptor"/> class.
		/// </summary>
		/// <param name="validator">The validator.</param>
		public ExceptionValidatorInterceptor(IValidator validator)
		{
			this._validator = validator;
		}

		/// <summary>
		/// Intercepts the specified invocation.
		/// </summary>
		/// <param name="invocation">The invocation.</param>
		public override void Intercept(IInvocation invocation)
		{
			invocation.Proceed();

			if(!invocation.Method.Name.StartsWith("set_"))
				return;

			var messages = _validator
				.Validate(invocation.Proxy, invocation.Method.Name.Substring(4))
				.Select(x => x.Message)
				.ToArray();

			if(!messages.Any())
				return;

			throw new ValidationException(string.Join(Environment.NewLine, messages));
		}
	}
}

