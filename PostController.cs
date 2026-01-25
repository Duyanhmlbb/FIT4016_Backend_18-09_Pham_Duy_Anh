using Microsoft.AspNetCore.Mvc;
using PostManagementApp.Models;
using PostManagementApp.Services;
namespace PostManagementApp.Controllers;
public class PostController : Controller
{
private readonly IPostService _postService;
public PostController(IPostService postService)
{
_postService = postService;
}
public IActionResult Index()
=> View(_postService.GetAll());
public IActionResult Details(int id)
{
var post = _postService.GetById(id);
if (post == null) return NotFound();
return View(post);
}
public IActionResult Create() => View();
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Post post)
{
if (!ModelState.IsValid) return View(post);
_postService.Add(post);
return RedirectToAction(nameof(Index));
}
public IActionResult Edit(int id)
{
var post = _postService.GetById(id);
if (post == null) return NotFound();
return View(post);
}
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(int id, Post post)
{
if (id != post.Id) return NotFound();
_postService.Update(id, post);
return RedirectToAction(nameof(Index));
}
public IActionResult Delete(int id)
{
_postService.Delete(id);
return RedirectToAction(nameof(Index));
}
}