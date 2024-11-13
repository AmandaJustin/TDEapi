using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private static List<Cliente> clientes = new List<Cliente>();

    [HttpGet]
    public ActionResult<IEnumerable<Cliente>> GetAll()
    {
        return clientes;
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> GetById(int id)
    {
        Cliente? clienteEncontrado = null;

        foreach (var cliente in clientes)
        {
            if (cliente.Id == id)
            {
                clienteEncontrado = cliente;
                break;
            }
        }

        if (clienteEncontrado == null)
            return NotFound();

        return clienteEncontrado;
    }

    [HttpPost]
    public ActionResult Post(Cliente cliente)
    {
        cliente.Id = clientes.Count + 1;
        clientes.Add(cliente);
        return CreatedAtAction(nameof(GetAll), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Cliente clienteAtualizado)
    {
        Cliente? clienteEncontrado = null;

        foreach (var cliente in clientes)
        {
            if (cliente.Id == id)
            {
                clienteEncontrado = cliente;
                break;
            }
        }

        if (clienteEncontrado == null)
            return NotFound();

        clienteEncontrado.Nome = clienteAtualizado.Nome;
        clienteEncontrado.Email = clienteAtualizado.Email;
        clienteEncontrado.Telefone = clienteAtualizado.Telefone;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        Cliente? clienteParaRemover = null;

        foreach (var cliente in clientes)
        {
            if (cliente.Id == id)
            {
                clienteParaRemover = cliente;
                break;
            }
        }

        if (clienteParaRemover == null)
            return NotFound();

        clientes.Remove(clienteParaRemover);
        return NoContent();
    }
}