using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BonSoChinContext;
using VBBContext;
using Forum = BonSoChinContext.Forum;
using Message = BonSoChinContext.Message;

namespace BonSoChinConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            //BackgroundWorker worker = new BackgroundWorker();
            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            //worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            //worker.RunWorkerAsync();
            //ConvertUser();
            ConvertForum();
            ConvertThread();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ConvertUser();
            ConvertForum();
            ConvertThread();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Convert OK!"); 
        }


        private void ConvertThread()
        {

        }

        private void ConvertForum()
        {
            BonSoChinDataContext bonSoChinContext = new BonSoChinDataContext();

            VBBDataContext context = new VBBDataContext();

            var forum4source = (from Forum in bonSoChinContext.Forums
                               select Forum);

            foreach (Forum forum4 in forum4source)
            {
                VBBContext.Forum vForum = new VBBContext.Forum();

                vForum.Title = forum4.Forumname;
                vForum.Titleclean = forum4.Forumname;
                vForum.Description = forum4.Forumdescription;
                vForum.Descriptionclean = forum4.Forumdescription;
                vForum.Displayorder = 1;
                // replycount
                vForum.Replycount = 0;
                vForum.Lastpost = 0;
                vForum.Lastposter = "";
                vForum.Lastposterid = 0;
                vForum.Lastpostid = 0;
                vForum.Lastthread = "";
                vForum.Lastthreadid = 0;
                vForum.Newpostemail = "";
                vForum.Newthreademail = "";
                vForum.Parentid = -1;
                vForum.Parentlist = "";
                vForum.Childlist = "";
                vForum.Defaultsortfield = "lastpost";
                vForum.Defaultsortorder = "desc";
                vForum.Threadcount = 0;
                vForum.Replycount = 0;

                PopulateUShort(vForum);
                context.Forums.InsertOnSubmit(vForum);

                context.SubmitChanges();

                var vForumId = (from vForum1 in context.Forums select vForum1.Forumid).Max();

                vForum.Forumid = vForumId;
                vForum.Parentlist = vForumId + ",-1";
                vForum.Childlist = vForumId + ",-1";

                context.SubmitChanges();

                // insert thread
                var thread4source = (from Message1 in bonSoChinContext.Messages
                               where Message1.Forumid == forum4.Forumid
                                && (Message1.Messageparentid.Equals("") || Message1.Messageparentid == null)
                               select Message1);

                foreach (Message thread4 in thread4source)
                {
                    Thread vThread = new Thread();
                    vThread.Title = thread4.Messagetopic;
                    vThread.Prefixid = "";
                    vThread.Forumid = vForumId;
                    vThread.Open = 1;

                    #region thread user
                    var postMemberInThread = (from member1 in bonSoChinContext.Members
                                              where (member1.Memberid == thread4.Memberidauthor)
                                              select member1).FirstOrDefault();
                    if (postMemberInThread == null)
                    {
                        var postUserInThread = (from user1 in context.Users
                                                where user1.Username.Equals(thread4.Messageauthor)
                                                select user1).FirstOrDefault();
                        if (postUserInThread != null)
                        {
                            vThread.Postuserid = postUserInThread.Userid;
                            vThread.Postusername = postUserInThread.Username;
                        }
                        else
                        {
                            User user = new User();
                            user.Username = thread4.Messageauthor.Trim();
                            user.Password = "";
                            user.Usergroupid = 2;
                            user.Passworddate = DateTime.Now;
                            user.Email = "a@a.com";
                            user.Showvbcode = 1;
                            user.Showbirthday = 0;
                            user.Usertitle = "Junior Member";
                            user.Usertitle = "aaa";
                            user.Joindate = 1273158780;
                            //ConvertToUnixTimestamp(member.Memberdateadded);
                            user.Lastvisit = 1273158780;
                            user.Daysprune = -1;
                            user.Lastactivity = 1273158780;
                            user.Reputation = 10;
                            user.Reputationlevelid = 5;
                            user.Timezoneoffset = "7";
                            user.Options = 45108311;
                            user.Birthday = "";
                            user.Birthdaysearch = DateTime.Now;
                            user.Posts = 0;
                            user.Maxposts = -1;
                            user.Startofweek = 1;
                            user.Autosubscribe = -1;
                            user.Salt = "";
                            user.Showblogcss = 1;
                            string img = "000.gif";
                            PopulateUShort(user);
                            context.Users.InsertOnSubmit(user);

                            context.SubmitChanges();

                            vThread.Postusername = user.Username;
                            vThread.Postuserid = (int)(from user1 in context.Users
                                                       select user1.Userid).Max();
                        }

                    } 
                    else
                    {
                        var postUserInThread = (from user1 in context.Users
                                                where user1.Username.Equals(postMemberInThread.Memberlogin.Trim())
                                                select user1).FirstOrDefault();
                        vThread.Postuserid = postUserInThread.Userid;
                        vThread.Postusername = postMemberInThread.Memberlogin;
                    }
                    #endregion

                    vThread.Lastposter = "";
                    vThread.Notes = "";
                    vThread.Similar = "";

                    PopulateUShort(vThread);
                    context.Threads.InsertOnSubmit(vThread);

                    context.SubmitChanges();

                    var vThreadId = (from vThread1 in context.Threads 
                                     select vThread1.Threadid).Max();

                    vForum.Threadcount++;

                    vThread.Replycount = 0;

                    // insert post
                    var post4source = (from Message1 in bonSoChinContext.Messages
                                         where Message1.Forumid == forum4.Forumid
                                          && (Message1.Messageparentid == thread4.Messageid)
                                         orderby Message1.Messageid ascending 
                                         select Message1 );
                    int postId = 0;
                    foreach (Message post4 in post4source)
                    {
                        Post vPost = new Post();
                        vPost.Threadid = vThreadId;
                        vPost.Title = "";
                        vPost.Pagetext = post4.Messagecontent;
                        vPost.Allowsmilie = 1;
                        vPost.Ipaddress = "127.0.0.1";
                        vPost.Visible = 1;
                        vPost.Parentid = postId;


                        #region post user
                        postMemberInThread = (from member1 in bonSoChinContext.Members
                                              where (member1.Memberid == post4.Memberidauthor)
                                                  select member1).FirstOrDefault();
                        if (postMemberInThread == null)
                        {
                            var postUserInThread = (from user1 in context.Users
                                                    where user1.Username.Equals(post4.Messageauthor)
                                                    select user1).FirstOrDefault();
                            if (postUserInThread != null)
                            {
                                vPost.Userid = postUserInThread.Userid;
                                vPost.Username = postUserInThread.Username;
                            }
                            else
                            {
                                User user = new User();
                                user.Username = post4.Messageauthor.Trim();
                                user.Password = "";
                                user.Usergroupid = 2;
                                user.Passworddate = DateTime.Now;
                                user.Email = "a@a.com";
                                user.Showvbcode = 1;
                                user.Showbirthday = 0;
                                user.Usertitle = "Junior Member";
                                user.Usertitle = "aaa";
                                user.Joindate = 1273158780;
                                //ConvertToUnixTimestamp(member.Memberdateadded);
                                user.Lastvisit = 1273158780;
                                user.Daysprune = -1;
                                user.Lastactivity = 1273158780;
                                user.Reputation = 10;
                                user.Reputationlevelid = 5;
                                user.Timezoneoffset = "7";
                                user.Options = 45108311;
                                user.Birthday = "";
                                user.Birthdaysearch = DateTime.Now;
                                user.Posts = 0;
                                user.Maxposts = -1;
                                user.Startofweek = 1;
                                user.Autosubscribe = -1;
                                user.Salt = "";
                                user.Showblogcss = 1;
                                string img = "000.gif";
                                PopulateUShort(user);
                                context.Users.InsertOnSubmit(user);

                                context.SubmitChanges();

                                vPost.Username = user.Username;
                                vPost.Userid = (int)(from user1 in context.Users
                                                           select user1.Userid).Max();
                            }

                        }
                        else
                        {
                            var postUserInThread = (from user1 in context.Users
                                                    where user1.Username.Equals(postMemberInThread.Memberlogin.Trim())
                                                    select user1).FirstOrDefault();
                            vPost.Userid = postUserInThread.Userid;
                            vPost.Username = postMemberInThread.Memberlogin;
                        }
                        #endregion


                        PopulateUShort(vPost);
                        context.Posts.InsertOnSubmit(vPost);

                        context.SubmitChanges();

                        postId = (int) (from vPost1 in context.Posts
                                  select vPost1.Postid).Max();

                        vThread.Replycount++;

                        vForum.Threadcount++;
                        vForum.Replycount++;
                    }
                }
            }
        }

        private void ConvertUser()
        {
            BonSoChinDataContext bonSoChinContext = new BonSoChinDataContext();
            VBBDataContext context = new VBBDataContext();

            var avatarsource = (from member in bonSoChinContext.Members
                               select member.Memberimage).Distinct<string>();

            foreach (string avatarImg in avatarsource)
            {
                string img;
                if (avatarImg == null)
                    img = "000.gif";
                else
                    img = avatarImg.ToString();
                
                Avatar avatar = new Avatar();
                string number = img.Substring(0, img.IndexOf("."));
                number = RemoveAllSpecialCharacter(number);
                avatar.Avatarid = Int32.Parse(number);
                avatar.Avatarpath = img;
                avatar.Displayorder = 1;
                avatar.Imagecategoryid = 3;
                avatar.Title = "";
                avatar.Minimumposts = 0;
                context.Avatars.InsertOnSubmit(avatar);
            }
            
            context.SubmitChanges();
            var result = from member in bonSoChinContext.Members
                         select member;
            foreach (Member member in result)
            {
                string salt = FetchUserSalt(3);
                

                User user = new User();
                user.Userid = (uint)member.Memberid;
                user.Username = member.Memberlogin.Trim();
                user.Password = CreatePassword(member.Memberpassword.Trim(), salt);
                switch (member.Securitylevelid)
                {
                    case 1:
                        user.Usergroupid = 2;
                        break;
                    case 2:
                        user.Usergroupid = 7;
                        break;
                    case 3:
                        user.Usergroupid = 6;
                        break;
                    default:
                        user.Usergroupid = 2;
                        break;
                }
                
                
                
                user.Passworddate = DateTime.Now;
                user.Email = member.Memberemail;
                user.Showvbcode = 1;
                user.Showbirthday = 0;
                user.Usertitle = "Junior Member";
                user.Usertitle = (from title in context.Usertitles
                                  where title.Minposts < member.Numberofmessages
                                  orderby title.Usertitleid ascending
                                  select title.Title).FirstOrDefault();
                user.Joindate = 1273158780;
                //ConvertToUnixTimestamp(member.Memberdateadded);
                user.Lastvisit = 1273158780;
                user.Daysprune = -1;
                user.Lastactivity = 1273158780;
                user.Reputation = 10;
                user.Reputationlevelid = 5;
                user.Timezoneoffset = "7";
                user.Options = 45108311;
                user.Birthday = member.Memberdateadded.Value.ToString("yyyy-MM-dd");
                user.Birthdaysearch = DateTime.Now;
                user.Posts = (long)member.Numberofmessages;
                user.Maxposts = -1;
                user.Startofweek = 1;
                user.Autosubscribe = -1;
                user.Salt = salt;
                user.Showblogcss = 1;
                string img = "000.gif";
                if (member.Memberimage != null)
                {
                    img = member.Memberimage;
                }

                user.Avatarid =
                    (short)(from avt in context.Avatars where avt.Avatarpath.Equals(img) select avt.Avatarid).FirstOrDefault();
                
                /*user.Membergroupids = "";
                user.Assetposthash = "";
                user.Displaygroupid = 0;
                user.Styleid = 0;
                user.Customtitle = 0;
                user.Parentemail = "";
                user.Homepage = "";
                user.Icq = "";
                user.Skype = "";
                user.Aim = "";
                user.Yahoo = "";
                user.Msn = "";
                user.Lastpost = 0;
                user.Ipaddress = "";*/
                PopulateUShort(user);
                context.Users.InsertOnSubmit(user);
                
                // userfield
                Userfield userfield = new Userfield();
                
                userfield.Userid = (uint)member.Memberid;
                context.Userfields.InsertOnSubmit(userfield);

                // usertextfield
                Usertextfield usertextfield = new Usertextfield();
                usertextfield.Userid = (uint)member.Memberid;
                context.Usertextfields.InsertOnSubmit(usertextfield);
                //}
            }

            context.SubmitChanges();
        }

        private string RemoveAllSpecialCharacter(string number)
        {
            return number.Replace("\"", "");
        }

        private void PopulateUShort(object user)
        {
            PropertyInfo[] propertyInfos = user.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                MethodInfo getMethod = propertyInfo.GetGetMethod();
                if (getMethod != null)
                {
                    if (propertyInfo.PropertyType.Name.Equals(typeof(ushort).Name))
                    {
                        object obj = propertyInfo.GetValue(user, null);
                        if (obj == null)
                            propertyInfo.SetValue(user, 0, null);
                    }

                    if (propertyInfo.PropertyType.Name.Equals(typeof(string).Name))
                    {
                        object obj = propertyInfo.GetValue(user, null);
                        if (obj == null)
                            propertyInfo.SetValue(user, "", null);
                    }
                }
            }
        }

        private string CreatePassword(string memberPassword, string salt)
        {
            return MD5Calc(MD5Calc(memberPassword) + salt);
        }

        string FetchUserSalt(int length)
        {
            var salt = "";
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random();

                salt += (char)(rand.Next(32, 126));
            }
            return salt;
        }
        string MD5Calc(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }

        private double ConvertToUnixTimestamp(DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (double)span.TotalSeconds;
        }

        private long ConvertToUnixTimestamp(DateTime? value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value.Value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (long)span.TotalSeconds;
        }
    }
}
