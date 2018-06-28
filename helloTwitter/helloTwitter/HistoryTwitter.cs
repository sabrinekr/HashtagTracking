using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using System.Configuration;
using TweetSharp;
using System.Runtime.CompilerServices;

namespace helloTwitter
{
    class HistoryTwitter
    {
        public static string _consumerKey = "fd8VhHfCwtDEmHoHlUoZkvnFM"; 
        public static string _consumerSecret = "Tu9JAuO5hlzyny8G6zit21LGNfa914QzFEOLhWHGftxS4aqdIE"; 
        public static string _accessToken = "4166329995-jg5NITsdCU4fgaeIlu9w2ncSvuve6PIaIetx3mI";  
        public static string _accessTokenSecret = "b3C1POXMx4tBz29oMXwrWaqqxcg3FclGXp3EqRItz8vSn";  
        private static object syncLock = new object();
        public static  void History()
        {
            lock (syncLock)
            {
                TwitterService twitterService = new TwitterService(_consumerKey, _consumerSecret);
                twitterService.AuthenticateWith(_accessToken, _accessTokenSecret);

                int tweetcount = 1;
                var tweets_search = twitterService.Search(new SearchOptions { Q = "#internship", Resulttype = TwitterSearchResultType.Popular, Count = 15 });
                //Resulttype can be TwitterSearchResultType.Popular or TwitterSearchResultType.Mixed or TwitterSearchResultType.Recent  
                List<TwitterStatus> resultList = new List<TwitterStatus>(tweets_search.Statuses);
                foreach (var tweet in tweets_search.Statuses)
                {
                    try
                    {
                        //tweet.User.ScreenName;  
                        //tweet.User.Name;   
                        //tweet.Text; // Tweet text  
                        //tweet.RetweetCount; //No of retweet on twitter  
                        //tweet.User.FavouritesCount; //No of Fav mark on twitter  
                        //tweet.User.ProfileImageUrl; //Profile Image of Tweet  
                        //tweet.CreatedDate; //For Tweet posted time  
                        //"https://twitter.com/intent/retweet?tweet_id=" + tweet.Id;  //For Retweet 
                        //"https://twitter.com/intent/favorite?tweet_id=" + tweet.Id; //For Favorite  

                        //Above are the things we can also get using TweetSharp.  
                        Console.WriteLine("Sr.No: " + (tweetcount) + "\n" + tweet.User.Name + "\nDate : " + tweet.CreatedDate + "\nId : " + "https://twitter.com/intent/retweet?tweet_id=" + tweet.Id + " \n Text :" + tweet.Text);
                        tweetcount++;
                    }
                    catch { }
                }
                Console.ReadLine();
            }
        }
    }
}
