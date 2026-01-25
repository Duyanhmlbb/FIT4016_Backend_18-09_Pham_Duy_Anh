using PostManagementApp.Models;
namespace PostManagementApp.Services;
public interface IPostService
{
List<Post> GetAll();
Post? GetById(int id);
void Add(Post post);
void Update(int id, Post post);
void Delete(int id);
}