namespace TodoListMinimal.Entity
{
    public static class PessoaRouter
    {
        static List<Pessoa> pessoas = new List<Pessoa>()
        {
            new Pessoa() {Id = Guid.NewGuid(), Nome = "Diogo"},
            new Pessoa() {Id = Guid.NewGuid(), Nome = "Aline"},
            new Pessoa() {Id = Guid.NewGuid(), Nome = "Alícia"},
        };

        public static void addPessoaRouter(this WebApplication app)
        {
            app.MapGet("/pessoas/", () =>
            {
                return pessoas;
            });

            app.MapGet("/pessoas/{nome}", (string nome) =>
            {
                return pessoas.FirstOrDefault(i => i.Nome == nome);
            });

            app.MapPost("/pessoas/", (Pessoa pessoa) =>
            {
                pessoa.Id = Guid.NewGuid();
                pessoas.Add(pessoa);
                return Results.Ok(pessoa);
            });

            app.MapPut("/pessoas/{id:guid}", (Guid id, Pessoa pessoa) =>
            {
                var encontrado = pessoas.Find(x => x.Id == id);

                if (encontrado == null)
                    return Results.NotFound();

                encontrado.Nome = pessoa.Nome;

                return Results.Ok(encontrado);
            });
        }
    }
}
