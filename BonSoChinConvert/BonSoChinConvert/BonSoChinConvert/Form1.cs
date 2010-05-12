using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

            /*textBox1.Text = ConvertToUnixTimestamp(DateTime.Now).ToString();
            return;*/
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.WorkerReportsProgress = true;
            ConvertButton.Enabled = false;
            worker.RunWorkerAsync();
            /*ConvertUser();
            ConvertForum();
            ConvertThread();*/
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UserProgress progress = e.UserState as UserProgress;
            if(progress!=null)
            {
                textBox1.Text = " Dang convert bang " + progress.TableName + " ; record : " + progress.Records + " / " +
                                progress.TotalRecords;
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ConvertUser((BackgroundWorker)sender);
            ConvertForum((BackgroundWorker)sender);
            ConvertThread();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox1.Text = " Convert thanh cong";
            ConvertButton.Enabled = true;
            MessageBox.Show("Convert OK!"); 
        }


        private void ConvertThread()
        {

        }

        private void ConvertForum(BackgroundWorker sender)
        {
            BonSoChinDataContext bonSoChinContext = new BonSoChinDataContext();
            VBBDataContext context = new VBBDataContext();

            // process null users
            /*var lackingMembers = from msg in bonSoChinContext.Messages
                                 from member in bonSoChinContext.Members
                                 where msg.Messageauthor NotFiniteNumberException in*/


            var forum4source = (from fr in bonSoChinContext.Forums
                                select fr);
            int maxVForumId = (from vForum1 in context.Forums select vForum1.Forumid).Max();

            long maxVThreadId = (from vThread1 in context.Threads
                             select vThread1.Threadid).Max();

            int maxPostId = (int)(from vPost1 in context.Posts
                           select vPost1.Postid).Max();
            int forumcount = 1;
            string tempUser = "tempUser";
            int tempUserCount = 1;

            foreach (Forum forum in forum4source)
            {
                
                VBBContext.Forum vForum = new VBBContext.Forum();

                vForum.Title = forum.Forumname;
                vForum.Titleclean = forum.Forumname;
                vForum.Description = forum.Forumdescription;
                vForum.Descriptionclean = forum.Forumdescription;
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
                vForum.Options = 221127;

                PopulateUShort(vForum);
                

                //context.SubmitChanges();

                //int vForumId = (from vForum1 in context.Forums select vForum1.Forumid).Max();
                int vForumId = ++maxVForumId;
                vForum.Forumid = vForumId;
                vForum.Parentlist = vForumId + ",-1";
                vForum.Childlist = vForumId + ",-1";

                //context.SubmitChanges();
                int forumId = forum.Forumid;
                // insert thread
                var thread4source = (from message in bonSoChinContext.Messages
                               where message.Forumid == forumId
                                && (message.Messageparentid.Equals("") || message.Messageparentid == null)
                                orderby message.Messagedateentered ascending 
                               select message);

                int threadCount = 1;
                sender.ReportProgress(10, new UserProgress("thread", threadCount++, thread4source.Count()));

                foreach (Message thread in thread4source)
                {
                    var vThreadId = ++maxVThreadId;
                    Thread vThread = new Thread();
                    vThread.Title = thread.Messagetopic;
                    vThread.Prefixid = "";
                    vThread.Forumid = vForumId;
                    vThread.Open = 1;
                    vThread.Dateline = ConvertToUnixTimestamp(thread.Messagedateentered);
                    
                    #region thread user
                    var postMemberInThread = (from member1 in bonSoChinContext.Members
                                              where (member1.Memberid == thread.Memberidauthor)
                                              select member1).FirstOrDefault();
                    if (postMemberInThread == null)
                    {
                        var postUserInThread = (from user1 in context.Users
                                                where user1.Username.Equals(thread.Messageauthor)
                                                select user1).FirstOrDefault();
                        if (postUserInThread != null)
                        {
                            vThread.Postuserid = postUserInThread.Userid;
                            vThread.Postusername = postUserInThread.Username;
                        }
                        else
                        {
                            User user = new User();
                            user.Username = tempUser + string.Format("{0:000}",tempUserCount++);
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
                    
                    // create first post
                    int vPostId = 0;
                    if (vPostId == 0)
                    {
                        vThread.Firstpostid = maxPostId + 1;
                    }
                    vPostId = ++maxPostId;
                    // 1st post entered
                    Post v1Post = new Post();
                    v1Post.Threadid = vThreadId;
                    v1Post.Title = "";
                    v1Post.Dateline = ConvertToUnixTimestamp(thread.Messagedateentered);
                    v1Post.Pagetext = thread.Messagecontent;
                    v1Post.Allowsmilie = 1;
                    v1Post.Ipaddress = "127.0.0.1";
                    v1Post.Visible = 1;
                    v1Post.Parentid = vPostId;
                    v1Post.Userid = vThread.Postuserid;
                    v1Post.Username = vThread.Postusername;

                    // insert post parser
                    Postparsed postparsed1 = new Postparsed();
                    postparsed1.Dateline = v1Post.Dateline;
                    postparsed1.Postid = vPostId;
                    postparsed1.Styleid = 1;
                    postparsed1.Languageid = 1;
                    postparsed1.Hasimages = 0;
                    postparsed1.Pagetexthtml = v1Post.Pagetext;
                    context.Posts.InsertOnSubmit(v1Post);
                    context.Postparseds.InsertOnSubmit(postparsed1);


                    vThread.Lastpost = v1Post.Dateline;
                    vThread.Lastposter = v1Post.Username;
                    vThread.Lastposterid = v1Post.Userid;
                    vThread.Lastpostid = vPostId;

                    vForum.Lastpost = (int)vThread.Lastpost;
                    vForum.Lastposter = vThread.Lastposter;
                    vForum.Lastposterid = vThread.Lastposterid;
                    vForum.Lastpostid = vThread.Lastpostid;

                    vForum.Lastthread = vThread.Dateline.ToString();
                    vForum.Lastthreadid = vThreadId;



                    //context.SubmitChanges();

                    /*var vThreadId = (from vThread1 in context.Threads 
                                     select vThread1.Threadid).Max();*/
                    
                    
                    vForum.Threadcount++;
                    vThread.Replycount = 0;
                    int threadId = thread.Messageid;
                    // insert post
                    var post4source = (from message1 in bonSoChinContext.Messages
                                        where message1.Forumid == forumId
                                          && (message1.Messageparentid == threadId)
                                         orderby message1.Messageid ascending 
                                         select message1 );

                    
                    
                    /*postId = (int)(from vPost1 in context.Posts
                                   select vPost1.Postid).Max();*/
                    
                    
                    int postCount = 1;
                    //sender.ReportProgress(10, new UserProgress("post", postCount++, post4source.Count()));
                    foreach (Message post in post4source)
                    {
                        vPostId = ++maxPostId;

                        Post vPost = new Post();
                        vPost.Threadid = vThreadId;
                        vPost.Title = "";
                        vPost.Dateline = ConvertToUnixTimestamp(post.Messagedateentered);
                        vPost.Pagetext = post.Messagecontent;
                        vPost.Allowsmilie = 1;
                        vPost.Ipaddress = "127.0.0.1";
                        vPost.Visible = 1;
                        vPost.Parentid = vPostId;


                        #region post user
                        postMemberInThread = (from member1 in bonSoChinContext.Members
                                              where (member1.Memberid == post.Memberidauthor)
                                                  select member1).FirstOrDefault();
                        if (postMemberInThread == null)
                        {
                            var postUserInThread = (from user1 in context.Users
                                                    where user1.Username.Equals(post.Messageauthor)
                                                    select user1).FirstOrDefault();
                            if (postUserInThread != null)
                            {
                                vPost.Userid = postUserInThread.Userid;
                                vPost.Username = postUserInThread.Username;
                            }
                            else
                            {
                                string salt = FetchUserSalt();
                                User user = new User();
                                user.Username = tempUser + string.Format("{0:000}", tempUserCount++);
                                user.Password = CreatePassword("bscpassword",salt);
                                user.Usergroupid = 2;
                                user.Passworddate = DateTime.Now;
                                user.Email = "a@a.com";
                                user.Showvbcode = 1;
                                user.Showbirthday = 0;
                                user.Usertitle = "Junior Member";
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
                                user.Salt = salt;
                                user.Showblogcss = 1;
                                string img = "000.gif";
                                PopulateUShort(user);
                                context.Users.InsertOnSubmit(user);

                                context.SubmitChanges();

                                vPost.Username = MySqlEscape(user.Username);
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
                        //context.SubmitChanges();

                        /*postId = (int) (from vPost1 in context.Posts
                                  select vPost1.Postid).Max();*/

                        vThread.Replycount++;

                        vForum.Threadcount++;
                        vForum.Replycount++;
                        postCount++;
                        if(postCount == post4source.Count())
                        {
                            vThread.Lastpostid = vPostId;
                            vThread.Lastposter = vPost.Username;
                            vThread.Lastposterid = vPost.Userid;
                            vThread.Lastpost = vPost.Dateline;
                        }

                        // update thread & forum
                        vThread.Lastpost = vPost.Dateline;
                        vThread.Lastposter = vPost.Username;
                        vThread.Lastposterid = vPost.Userid;
                        vThread.Lastpostid = vPostId;

                        vForum.Lastpost = (int)vThread.Lastpost;
                        vForum.Lastposter = vThread.Lastposter;
                        vForum.Lastposterid = vThread.Lastposterid;
                        vForum.Lastpostid = vThread.Lastpostid;
                        
                        //postId++;
                        context.Posts.InsertOnSubmit(vPost);

                        // insert post parser
                        Postparsed postparsed = new Postparsed();
                        postparsed.Dateline = vPost.Dateline;
                        postparsed.Postid = vPostId;
                        postparsed.Styleid = 1;
                        postparsed.Languageid = 1;
                        postparsed.Hasimages = 0;
                        postparsed.Pagetexthtml = vPost.Pagetext;
                        context.Postparseds.InsertOnSubmit(postparsed);
                    }

                    vForum.Lastthread = vThread.Dateline.ToString();
                    vForum.Lastthreadid = vThreadId;

                    Threadview vThreadview = new Threadview();
                    vThreadview.Threadid = vThreadId;
                    //context.Threadviews.InsertOnSubmit(vThreadview);
                    context.Threads.InsertOnSubmit(vThread);
                }

                context.Forums.InsertOnSubmit(vForum);
            }

            context.SubmitChanges();
        }

        #region Convert Users
        private void ConvertUser(BackgroundWorker sender)
        {
            BonSoChinDataContext bonSoChinContext = new BonSoChinDataContext();
            VBBDataContext context = new VBBDataContext();

            var avatarsource = (from member in bonSoChinContext.Members
                                select member.Memberimage).Distinct<string>();

            int count = 1;
            sender.ReportProgress(10, new UserProgress("avatar", count++, avatarsource.Count()));

            // ----------------------- AVATARS TABLE ------------------------------------
            foreach (string avatarImg in avatarsource)
            {
                string img;
                if (avatarImg == null)
                    img = "000.gif";
                else
                    img = avatarImg.ToString();

                string number = img.Substring(0, img.IndexOf("."));
                number = RemoveAllSpecialCharacter(number);

                Avatar avatar = new Avatar
                {

                    Avatarid = Int32.Parse(number),
                    Avatarpath = img,
                    Displayorder = 1,
                    Imagecategoryid = 3,
                    Title = "",
                    Minimumposts = 0
                };
                context.Avatars.InsertOnSubmit(avatar);


            }
            context.SubmitChanges();

            // ----------------------- USERS TABLE ------------------------------------

            var result = from member in bonSoChinContext.Members
                         select member;

            count = 1;
            sender.ReportProgress(10, new UserProgress("user", count++, result.Count()));
            foreach (Member member in result)
            {
                string salt = FetchUserSalt(3);


                User user = new User
                {
                    Userid = (uint)member.Memberid,
                    Username = member.Memberlogin.Trim(),
                    Password = CreatePassword(member.Memberpassword.Trim(), salt),
                    Passworddate = DateTime.Now,
                    Email = member.Memberemail,
                    Showvbcode = 1,
                    Showbirthday = 0,
                    //Usertitle = "Junior Member",
                    Usertitle = (from title in context.Usertitles
                                 where title.Minposts < member.Numberofmessages
                                 orderby title.Usertitleid ascending
                                 select title.Title).FirstOrDefault(),
                    Joindate = ConvertToUnixTimestamp(member.Memberdateadded), //1273158780;
                    //ConvertToUnixTimestamp(member.Memberdateadded);
                    Lastvisit = 1273158780,
                    Daysprune = -1,
                    Lastactivity = 1273158780,
                    Reputation = 10,
                    Reputationlevelid = 5,
                    Timezoneoffset = "7",
                    Options = 45108311,
                    Birthday = member.Memberdateadded.Value.ToString("yyyy-MM-dd"),
                    Birthdaysearch = DateTime.Now,
                    Posts = (long)member.Numberofmessages,
                    Maxposts = -1,
                    Startofweek = 1,
                    Autosubscribe = -1,
                    Salt = salt,
                    Showblogcss = 1
                };
                string img = "000.gif";
                if (member.Memberimage != null)
                {
                    img = member.Memberimage;
                }

                user.Avatarid =
                    (short)(from avt in context.Avatars where avt.Avatarpath.Equals(img) select avt.Avatarid).FirstOrDefault();

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
        #endregion

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

        string FetchUserSalt(int length=3)
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

        private uint ConvertToUnixTimestamp(DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (uint)span.TotalSeconds;
        }

        private uint ConvertToUnixTimestamp(DateTime? value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value.Value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (uint)span.TotalSeconds;
        }
        public string MySqlEscape(string usString)
        {
            if (usString == null)
            {
                return null;
            }
            // SQL Encoding for MySQL Recommended here:
            // http://au.php.net/manual/en/function.mysql-real-escape-string.php
            // it escapes \r, \n, \x00, \x1a, baskslash, single quotes, and double quotes
            return Regex.Replace(usString, @"[\r\n\x00\x1a\\'""]", @"\$0");
        }
    }
    class UserProgress
    {
        public UserProgress(string tableName, int records, int totalRecords)
        {
            TableName = tableName;
            Records = records;
            TotalRecords = totalRecords;
        }

        public string TableName { get; set; }
        public int Records { get; set; }
        public int TotalRecords { get; set; }
    }
}
