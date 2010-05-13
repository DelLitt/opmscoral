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
            if (progress != null)
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
            ConvertArticle();
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

        private void ConvertArticle()
        {
            BonSoChinDataContext bonSoChinContext = new BonSoChinDataContext();
            VBBDataContext context = new VBBDataContext();

            short maxVForumId = (short)(from vForum1 in context.Forums
                               select vForum1.Forumid).Max();

            long maxVThreadId = (from vThread1 in context.Threads
                                 select vThread1.Threadid).Max();

            int maxPostId = (int)(from vPost1 in context.Posts
                                  select vPost1.Postid).Max();
            var vPostId = maxPostId;
            VBBContext.Forum vForum = new VBBContext.Forum
            {
                Title = "Article1",
                Titleclean = "Article1",
                Description = "Article1",
                Descriptionclean = "Article1",
                Displayorder = 1,
                // replycount
                Replycount = 0,
                Lastpost = 0,
                Lastposter = "",
                Lastposterid = 0,
                Lastpostid = 0,
                Lastthread = "",
                Lastthreadid = 0,
                Newpostemail = "",
                Newthreademail = "",
                Parentid = -1,
                Parentlist = "",
                Childlist = "",
                Defaultsortfield = "lastpost",
                Defaultsortorder = "desc",
                Threadcount = 0,
                Options = 221127,
            };
            PopulateUShort(vForum);
            short vForumId = (short) (maxVForumId + 1);
            short superForumId = vForumId;
            vForum.Forumid = (short)(maxVForumId + 1);
            vForum.Parentlist = vForumId + ",-1";
            vForum.Childlist = vForumId + ",-1";

            context.Forums.InsertOnSubmit(vForum);
            context.SubmitChanges();
            // ---------------------------------- CREATE SUB FORUM -----------------------------------
            var articleCategories4source = (from articles1 in bonSoChinContext.Articlecategories
                                            select articles1).ToList();

            foreach (Articlecategory articlecategory in articleCategories4source)
            {
                VBBContext.Forum vSubForum = new VBBContext.Forum
                {
                    Title = articlecategory.Articlecategory1,
                    Titleclean = articlecategory.Articlecategory1,
                    Description = articlecategory.Articlecategory1,
                    Descriptionclean = articlecategory.Articlecategory1,
                    Displayorder = 1,
                    // replycount
                    Replycount = 0,
                    Lastpost = 0,
                    Lastposter = "",
                    Lastposterid = 0,
                    Lastpostid = 0,
                    Lastthread = "",
                    Lastthreadid = 0,
                    Newpostemail = "",
                    Newthreademail = "",
                    Parentid = superForumId,
                    Parentlist = "",
                    Childlist = "",
                    Defaultsortfield = "lastpost",
                    Defaultsortorder = "desc",
                    Threadcount = 0,
                    Options = 221127,
                };
                PopulateUShort(vSubForum);
                ++vForumId;
                vSubForum.Forumid = vForumId;
                vSubForum.Parentlist = vForumId + "," + vSubForum.Parentid + ",-1";
                vSubForum.Childlist = vForumId + ",-1";

                // ---------------------------------- CREATE Thread -----------------------------------
                var article4source = (from articles1 in bonSoChinContext.Articles
                                      where articles1.Articlecategoryid == articlecategory.Articlecategoryid
                                      select articles1).ToList();

                foreach (Article article in article4source)
                {
                    var vThreadId = ++maxVThreadId;
                    int dtline = ConvertToUnixTimestamp(article.Articledateposted);
                    Thread vThread = new Thread();
                    vThread.Title = article.Articletitle;
                    vThread.Prefixid = "";
                    vThread.Forumid = vForumId;
                    vThread.Open = 1;
                    vThread.Visible = 1;
                    vThread.Dateline = ConvertToUnixTimestamp(article.Articledateposted);

                    var postMemberInThread = (from member1 in bonSoChinContext.Members
                                              where (member1.Memberid == article.Articlepostedby)
                                              select member1).FirstOrDefault();
                    var postUserInThread = (from user1 in context.Users
                                            where user1.Username.Equals(postMemberInThread.Memberlogin.Trim())
                                            select user1).FirstOrDefault();
                    vThread.Postuserid = postUserInThread.Userid;
                    vThread.Postusername = postMemberInThread.Memberlogin;

                    vThread.Lastposter = "";
                    vThread.Notes = "";
                    vThread.Similar = "";

                    PopulateUShort(vThread);
                    vPostId++;
                    
                    // 1st post entered
                    Post v1Post = new Post
                    {
                        Threadid = vThreadId,
                        Title = "",
                        Dateline = ConvertToUnixTimestamp(article.Articledateposted),
                        Pagetext = article.Articlecontent,
                        Allowsmilie = 1,
                        Ipaddress = "127.0.0.1",
                        Visible = 1,
                        Parentid = vPostId,
                        Userid = vThread.Postuserid,
                        Username = vThread.Postusername,
                    };

                    // insert post parser
                    Postparsed postparsed1 = new Postparsed
                    {
                        Dateline = v1Post.Dateline,
                        Postid = vPostId,
                        Styleid = 1,
                        Languageid = 1,
                        Hasimages = 0,
                        Pagetexthtml = v1Post.Pagetext,
                    };
                    
                    context.Posts.InsertOnSubmit(v1Post);
                    context.Postparseds.InsertOnSubmit(postparsed1);

                    UpdateStatusOfForumAndThread(vThread, vSubForum, v1Post, vPostId, vThreadId);
                    vForum.Threadcount++;
                    vThread.Firstpostid = vPostId;

                    vSubForum.Lastthread = vThread.Title.ToString();
                    vSubForum.Lastthreadid = vThreadId;

                    vForum.Lastthread = vThread.Title.ToString();
                    vForum.Lastthreadid = vThreadId;

                    vSubForum.Threadcount++;
                    vForum.Replycount ++;
                    vSubForum.Replycount ++;
                    vThread.Replycount = 0;

                    Threadview vThreadview = new Threadview();
                    vThreadview.Threadid = vThreadId;
                    context.Threads.InsertOnSubmit(vThread);
                }

                context.Forums.InsertOnSubmit(vSubForum);
            }
            context.SubmitChanges();
        }

        private void ConvertForum(BackgroundWorker sender)
        {
            BonSoChinDataContext bonSoChinContext = new BonSoChinDataContext();
            VBBDataContext context = new VBBDataContext();

            // process null users
            var lackingMembers = (from msg in bonSoChinContext.Messages
                                  where !bonSoChinContext.Members.Any(c => c.Memberid == msg.Memberidauthor)
                                  select msg.Messageauthor).Distinct<string>().ToList();
            string tempUser = "tempUser";
            int tempUserCount = 1;
            foreach (string lackingMember in lackingMembers)
            {
                string salt = FetchUserSalt(3);
                User user = new User
                                {
                                    Username = lackingMember,//tempUser + string.Format("{0:000}", tempUserCount++),
                                    Password = CreatePassword("bscpassword", salt),
                                    Usergroupid = 2,
                                    Passworddate = DateTime.Now,
                                    Email = "a@a.com",
                                    Showvbcode = 1,
                                    Showbirthday = 0,
                                    Usertitle = "Junior Member",
                                    Joindate = ConvertToUnixTimestamp(DateTime.Now),
                                    Lastvisit = 1273158780,
                                    Daysprune = -1,
                                    Lastactivity = 1273158780,
                                    Reputation = 10,
                                    Reputationlevelid = 5,
                                    Timezoneoffset = "7",
                                    Options = 45108311,
                                    Birthday = "",
                                    Birthdaysearch = DateTime.Now,
                                    Posts = 0,
                                    Maxposts = -1,
                                    Startofweek = 1,
                                    Autosubscribe = -1,
                                    Salt = salt,
                                    Showblogcss = 1,
                                };
                string img = "000.gif";
                user.Avatarid = (short)(from avt in context.Avatars where avt.Avatarpath.Equals(img) select avt.Avatarid).FirstOrDefault();
                PopulateUShort(user);
                context.Users.InsertOnSubmit(user);
            }
            context.SubmitChanges();

            var forum4source = (from fr in bonSoChinContext.Forums
                                select fr).ToList();
            int maxVForumId = (from vForum1 in context.Forums
                               select vForum1.Forumid).Max();

            long maxVThreadId = (from vThread1 in context.Threads
                                 select vThread1.Threadid).Max();

            int maxPostId = (int)(from vPost1 in context.Posts
                                  select vPost1.Postid).Max();
            int forumcount = 1;

            // ---------------------------------- CREATE FORUM -----------------------------------
            foreach (Forum forum in forum4source)
            {

                VBBContext.Forum vForum = new VBBContext.Forum
                                              {
                                                  Title = forum.Forumname,
                                                  Titleclean = forum.Forumname,
                                                  Description = forum.Forumdescription,
                                                  Descriptionclean = forum.Forumdescription,
                                                  Displayorder = 1,
                                                  // replycount
                                                  Replycount = 0,
                                                  Lastpost = 0,
                                                  Lastposter = "",
                                                  Lastposterid = 0,
                                                  Lastpostid = 0,
                                                  Lastthread = "",
                                                  Lastthreadid = 0,
                                                  Newpostemail = "",
                                                  Newthreademail = "",
                                                  Parentid = -1,
                                                  Parentlist = "",
                                                  Childlist = "",
                                                  Defaultsortfield = "lastpost",
                                                  Defaultsortorder = "desc",
                                                  Threadcount = 0,
                                                  Options = 221127,
                                              };
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
                                     orderby message.Messagedateentered
                                     select message).ToList();

                int threadCount = 0;
                // ---------------------------------- CREATE THREADS -----------------------------------
                foreach (Message thread in thread4source)
                {
                    sender.ReportProgress(10, new UserProgress("thread", threadCount++, thread4source.Count()));
                    var vThreadId = ++maxVThreadId;

                    Thread vThread = new Thread();
                    vThread.Title = thread.Messagetopic;
                    vThread.Prefixid = "";
                    vThread.Forumid = vForumId;
                    vThread.Open = 1;
                    vThread.Visible = 1;
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
                            #region useless
                            /*User user = new User();
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
                                                       select user1.Userid).Max();*/

                            #endregion
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
                    Post v1Post = new Post
                    {
                        Threadid = vThreadId,
                        Title = "",
                        Dateline = ConvertToUnixTimestamp(thread.Messagedateentered),
                        Pagetext = thread.Messagecontent,
                        Allowsmilie = 1,
                        Ipaddress = "127.0.0.1",
                        Visible = 1,
                        Parentid = vPostId,
                        Userid = vThread.Postuserid,
                        Username = vThread.Postusername,
                    };

                    // insert post parser
                    Postparsed postparsed1 = new Postparsed
                    {
                        Dateline = v1Post.Dateline,
                        Postid = vPostId,
                        Styleid = 1,
                        Languageid = 1,
                        Hasimages = 0,
                        Pagetexthtml = v1Post.Pagetext,
                    };

                    context.Posts.InsertOnSubmit(v1Post);
                    context.Postparseds.InsertOnSubmit(postparsed1);

                    UpdateStatusOfForumAndThread(vThread, vForum, v1Post, vPostId, vThreadId);

                    vForum.Lastthread = vThread.Dateline.ToString();
                    vForum.Lastthreadid = vThreadId;


                    #region useless
                    /*vThread.Lastpost = v1Post.Dateline;
                    vThread.Lastposter = v1Post.Username;
                    vThread.Lastposterid = v1Post.Userid;
                    vThread.Lastpostid = vPostId;

                    vForum.Lastpost = (int)vThread.Lastpost;
                    vForum.Lastposter = vThread.Lastposter;
                    vForum.Lastposterid = vThread.Lastposterid;
                    vForum.Lastpostid = vThread.Lastpostid;

                    vForum.Lastthread = vThread.Dateline.ToString();
                    vForum.Lastthreadid = vThreadId;*/

                    #endregion



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
                                       select message1).ToList();



                    /*postId = (int)(from vPost1 in context.Posts
                                   select vPost1.Postid).Max();*/


                    int postCount = 1;
                    // ---------------------------------- CREATE POSTS -----------------------------------
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
                                #region useless
                                /*string salt = FetchUserSalt();
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
                                                           select user1.Userid).Max();*/

                                #endregion
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
                        if (postCount == post4source.Count())
                        {
                            vThread.Lastpostid = vPostId;
                            vThread.Lastposter = vPost.Username;
                            vThread.Lastposterid = vPost.Userid;
                            vThread.Lastpost = vPost.Dateline;
                        }

                        // update thread & forum
                        UpdateStatusOfForumAndThread(vThread, vForum, vPost, vPostId, vThreadId);
                        #region useless
                        /*vThread.Lastpost = vPost.Dateline;
                        vThread.Lastposter = vPost.Username;
                        vThread.Lastposterid = vPost.Userid;
                        vThread.Lastpostid = vPostId;

                        vForum.Lastpost = (int)vThread.Lastpost;
                        vForum.Lastposter = vThread.Lastposter;
                        vForum.Lastposterid = vThread.Lastposterid;
                        vForum.Lastpostid = vThread.Lastpostid;*/

                        #endregion

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

                    vForum.Lastthread = vThread.Title.ToString();
                    vForum.Lastthreadid = vThreadId;

                    Threadview vThreadview = new Threadview();
                    vThreadview.Threadid = vThreadId;
                    context.Threads.InsertOnSubmit(vThread);
                }

                context.Forums.InsertOnSubmit(vForum);
                context.SubmitChanges();
            }

            context.SubmitChanges();
        }

        private void UpdateStatusOfForumAndThread(Thread vThread, VBBContext.Forum vForum, Post v1Post, int vPostId, long vThreadId)
        {
            vThread.Lastpost = v1Post.Dateline;
            vThread.Lastposter = v1Post.Username;
            vThread.Lastposterid = v1Post.Userid;
            vThread.Lastpostid = vPostId;

            vForum.Lastpost = (int)vThread.Lastpost;
            vForum.Lastposter = vThread.Lastposter;
            vForum.Lastposterid = vThread.Lastposterid;
            vForum.Lastpostid = vThread.Lastpostid;
        }

        #region Convert Users
        private void ConvertUser(BackgroundWorker sender)
        {
            BonSoChinDataContext bonSoChinContext = new BonSoChinDataContext();
            VBBDataContext context = new VBBDataContext();

            var avatarsource = (from member in bonSoChinContext.Members
                                select member.Memberimage).Distinct<string>().ToList();

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

            var result = (from member in bonSoChinContext.Members
                         select member).ToList();

            count = 1;
            sender.ReportProgress(10, new UserProgress("user", count++, result.Count()));
            foreach (Member member in result)
            {
                string salt = FetchUserSalt(3);


                int test = ConvertToUnixTimestamp(member.Memberdateadded);
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
                    Joindate = ConvertToUnixTimestamp(member.Memberdateadded), //1273158780,
                    //;
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

        string FetchUserSalt(int length = 3)
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

        private int ConvertToUnixTimestamp(DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            DateTime first = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            TimeSpan span;
            if(first.CompareTo(value) > 0 )
            {
                span = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());    
            }
            else
            {
                span = (value - first);    
            }
            

            //return the total seconds (which is a UNIX timestamp)
            return (int)span.TotalSeconds;
        }

        private int ConvertToUnixTimestamp(DateTime? value)
        {
            return ConvertToUnixTimestamp(value.Value);
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
