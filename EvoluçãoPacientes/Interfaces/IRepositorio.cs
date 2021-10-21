using System.Collections.Generic;

namespace EvoluçãoPacientes.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T retornaPorId(int id);
        void insere(T entidade);
        void excluir (int id);
        void atualiza(int id, T entidade);
        int proximoId();
    }
}