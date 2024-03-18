import instaloader

# Create an instance of Instaloader class
L = instaloader.Instaloader()

# Log in with your Instagram credentials
username = 'your_username'
password = 'your_password'
L.login(username, password)

# Download profile info
profile = instaloader.Profile.from_username(L.context, 'profile_name')
print("Username:", profile.username)
print("Full Name:", profile.full_name)
print("Bio:", profile.biography)

# Download posts and display the number of likes for each post
for post in profile.get_posts():
    print("Post:", post.shortcode)
    print("Likes:", post.likes)
    print("Caption:", post.caption)
    print("Comments:", post.comments)
    print("\n")
