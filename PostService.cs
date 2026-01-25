using PostManagementApp.Models;
namespace PostManagementApp.Services;
public class PostService : IPostService
{
private static readonly List<Post> _posts = new();
public List<Post> GetAll() => _posts;
public Post? GetById(int id)
=> _posts.FirstOrDefault(p => p.Id == id);
public void Add(Post post)
{
post.Id = _posts.Count == 0 ? 1 : _posts.Max(p => p.Id) + 1;
post.CreatedAt = DateTime.Now;
_posts.Add(post);
}
public void Update(int id, Post updated)
{
var post = GetById(id);
if (post == null) return;
post.Title = updated.Title;
post.Content = updated.Content;
post.UpdatedAt = DateTime.Now;
}
public void Delete(int id)
{
var post = GetById(id);
if (post != null)
_posts.Remove(post);
}
}