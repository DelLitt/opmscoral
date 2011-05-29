CREATE TABLE `pos_log` (                                
           `Id` bigint(20) NOT NULL auto_increment,              
           `Date` datetime NOT NULL,                             
           `Thread` varchar(255) NOT NULL,                       
           `Level` varchar(50) NOT NULL,                         
           `Logger` varchar(255) NOT NULL,                       
           `Message` text NOT NULL,                              
           `Exception` varchar(2000) default NULL,               
           `Pos_User` varchar(100) default NULL,                 
           `Pos_Action` varchar(100) default NULL,               
           PRIMARY KEY  (`Id`)                                   
         ) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8  