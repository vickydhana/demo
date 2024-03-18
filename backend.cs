using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;

class Program
{
    static async Task Main(string[] args)
    {
        // Initialize API options
        var userSession = new UserSessionData
        {
            UserName = "your_username",
            Password = "your_password"
        };

        // Create an instance of InstaApi
        var api = InstaApiBuilder.CreateBuilder()
            .SetUser(userSession)
            .Build();

        // Log in
        var loginResult = await api.LoginAsync();

        // Check if login was successful
        if (!loginResult.Succeeded)
        {
            Console.WriteLine($"Login failed: {loginResult.Info.Message}");
            return;
        }

        Console.WriteLine("Login successful!");

        // Retrieve profile info
        var currentUser = await api.GetCurrentUserAsync();
        if (currentUser.Succeeded)
        {
            var user = currentUser.Value.User;
            Console.WriteLine($"Username: {user.UserName}");
            Console.WriteLine($"Full Name: {user.FullName}");
            Console.WriteLine($"Bio: {user.Biography}");
        }
        else
        {
            Console.WriteLine($"Failed to retrieve profile info: {currentUser.Info.Message}");
        }

        // Retrieve recent posts
        var recentPosts = await api.GetUserMediaAsync("profile_name", PaginationParameters.MaxPagesToLoad(1));
        if (recentPosts.Succeeded)
        {
            foreach (var post in recentPosts.Value)
            {
                Console.WriteLine($"Post: {post.Code}");
                Console.WriteLine($"Likes: {post.LikesCount}");
                Console.WriteLine($"Caption: {post.Caption?.Text}");
                Console.WriteLine($"Comments: {post.CommentsCount}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"Failed to retrieve recent posts: {recentPosts.Info.Message}");
        }
    }
}
