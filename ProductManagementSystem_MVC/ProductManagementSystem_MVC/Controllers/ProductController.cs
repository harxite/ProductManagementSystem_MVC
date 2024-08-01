using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProductManagementSystem_MVC.Models;
using System.Threading.Tasks;


public class ProductController : Controller
{
    private readonly ProductRepository _repository;

    public ProductController(ProductRepository repository)
    {
        _repository = repository;
    }

    // GET: Product
    public async Task<IActionResult> Index()
    {
        var products = await _repository.GetAllProducts();
        return View(products);
    }

    // GET: Product/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var product = await _repository.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // GET: Product/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Product/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: Product/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _repository.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }


    // POST: Product/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _repository.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("", $"Database error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
            }
        }
        return View(product);
    }


    // GET: Product/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _repository.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Product/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int ProductId)
    {
        var product = await _repository.GetProductById(ProductId);
        if (product == null)
        {
            return NotFound();
        }

        await _repository.DeleteProduct(ProductId);
        return RedirectToAction(nameof(Index));
    }


}
