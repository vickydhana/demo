<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Instagram Posts</title>
</head>
<body>
    <div id="instagram-posts"></div>

    <script>
        // Replace with your Access Token
        const accessToken = 'YOUR_ACCESS_TOKEN';

        // API endpoint
        const apiUrl = `https://graph.instagram.com/me/media?fields=id,caption,media_type,media_url,permalink,timestamp&access_token=${accessToken}`;

        // Function to fetch Instagram posts
        async function fetchInstagramPosts() {
            try {
                const response = await fetch(apiUrl);
                const data = await response.json();
                return data.data;
            } catch (error) {
                console.error('Error fetching Instagram posts:', error);
            }
        }

        // Function to render posts
        async function renderPosts() {
            const posts = await fetchInstagramPosts();
            const container = document.getElementById('instagram-posts');

            posts.forEach(post => {
                const postElement = document.createElement('div');
                postElement.innerHTML = `
                    <a href="${post.permalink}" target="_blank">
                        <img src="${post.media_url}" alt="${post.caption}">
                    </a>
                    <p>${post.caption}</p>
                `;
                container.appendChild(postElement);
            });
        }

        // Call renderPosts function
        renderPosts();
    </script>
</body>
</html>
