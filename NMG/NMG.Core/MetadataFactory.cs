using NMG.Core.Domain;
using NMG.Core.Reader;

namespace NMG.Core
{
    public class MetadataFactory
    {
        public static IMetadataReader GetReader(ServerType serverType, string connectionStr)
        {
            IMetadataReader metadataReader;
            switch(serverType)
            {
                case ServerType.Oracle:
                    metadataReader = new OracleMetadataReader(connectionStr);
                    break;
                case ServerType.SqlServer:
                    metadataReader = new SqlServerMetadataReader(connectionStr);
                    break;
                case ServerType.SqlCe:
                    metadataReader = new SqlCeMetadataReader(connectionStr);
                    break;
                default:
                    metadataReader = new OracleMetadataReader(connectionStr);
                    break;
            }
            /*if (serverType == ServerType.Oracle)
            {
                
            }
            else
            {
                
            }*/
            return metadataReader;
        }
    }
}