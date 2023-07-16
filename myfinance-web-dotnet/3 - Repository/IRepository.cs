namespace myfinance_web_netcore.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        void Cadastrar(TEntity Entidade);
        void Excluir(int Id);
        List<TEntity> ListarRegistros();
        TEntity RetornarRegistro(int Id);
    }
}