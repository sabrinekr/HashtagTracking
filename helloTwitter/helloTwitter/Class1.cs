using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using System.Configuration;
namespace helloTwitter
{
    class Class1
    {
        public static void StreamTwitter()
        {
            // Authentication
            Auth.SetUserCredentials("fd8VhHfCwtDEmHoHlUoZkvnFM", "Tu9JAuO5hlzyny8G6zit21LGNfa914QzFEOLhWHGftxS4aqdIE", "4166329995-jg5NITsdCU4fgaeIlu9w2ncSvuve6PIaIetx3mI", "b3C1POXMx4tBz29oMXwrWaqqxcg3FclGXp3EqRItz8vSn");

            // Create the Stream
            var stream = Stream.CreateFilteredStream();

            // Keywords to Track
            stream.AddTrack("#worldcup #world");
            stream.AddTrack("#messi");

            // Message so you know its running
            Console.WriteLine("I am listening to Twitter");

            // Called when a tweet maching the tracker is produced
            stream.MatchingTweetReceived += (sender, arguments) =>
            {
                Console.WriteLine("New Tweet");
                Console.WriteLine(arguments.Tweet.Text);
            };

            stream.StartStreamMatchingAllConditions();
        }

    }
}