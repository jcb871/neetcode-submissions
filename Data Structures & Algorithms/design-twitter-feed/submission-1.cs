public class Tweet {
    public int Id {get; set; }
    public int UserId {get; set; }
    public int Time {get; set; }
}
public class Twitter {
    private int _tweetCount;
    private readonly Dictionary<int, List<Tweet>> _tweets;
    private readonly Dictionary<int, HashSet<int>> _followees;
    public Twitter() {
        _tweets = [];
        _followees = [];
    }
    
    public void PostTweet(int userId, int tweetId) {
        if(!_tweets.TryGetValue(userId, out List<Tweet> tweets)) {
            tweets = [];
            _tweets[userId] = tweets;
        }
        int tweetTime = ++_tweetCount;
        tweets.Add(new Tweet{ Id = tweetId, UserId = userId, Time = tweetTime });
    }
    
    public List<int> GetNewsFeed(int userId) {
        HashSet<int> authors = new();
        authors.Add(userId);
        if(_followees.TryGetValue(userId, out HashSet<int> followees)) {
            followees.ToList().ForEach(i=>authors.Add(i));
        }

        PriorityQueue<Tweet, int> maxHeap = new();
        List<int> feed = new(10);
        Dictionary<int, int> userTweetIndex = [];
        foreach(int author in authors) {
            if(!_tweets.TryGetValue(author, out List<Tweet> followeeTweets) || followeeTweets.Count == 0) continue;
            userTweetIndex[author] = followeeTweets.Count-1;
            Tweet currTweet = followeeTweets[followeeTweets.Count-1];
            maxHeap.Enqueue(currTweet, -currTweet.Time);            
        }

        for(int t=0; t<10; t++) {
            if(!maxHeap.TryDequeue(out Tweet tweet, out _)) break;
            feed.Add(tweet.Id);
            int tweetIndex = userTweetIndex[tweet.UserId];
            if(tweetIndex == 0 || !_tweets.TryGetValue(tweet.UserId, out List<Tweet> followeeTweets)) continue;
            userTweetIndex[tweet.UserId] = --tweetIndex;
            tweet = followeeTweets[tweetIndex];
            maxHeap.Enqueue(tweet, -tweet.Time);
        }

        return feed;
    }
    
    public void Follow(int followerId, int followeeId) {
        if(!_followees.TryGetValue(followerId, out HashSet<int> followees)) {
            followees = [];
            _followees[followerId] = followees;
        }
        followees.Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if(_followees.TryGetValue(followerId, out HashSet<int> followees)) {
            followees.Remove(followeeId);
        }
    }
}
