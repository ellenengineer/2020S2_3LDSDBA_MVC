using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;
using MVC;

namespace MVC.Aplicacao
{
    public class ProdutoAplicacao
    {
        private INFONEWContext _contexto;

        public ProdutoAplicacao(INFONEWContext contexto)
        {
            _contexto = contexto;
        }

        public string InertPRod(Produto prod)
        {
            try
            {
                if (prod != null)
                {
                    var produtoExiste = GetProdByCod(prod.CodProd);

                    if (produtoExiste == null)
                    {
                        _contexto.Add(prod);
                        _contexto.SaveChanges();

                        return "Produto cadastrado com sucesso!";
                    }
                    else
                    {
                        return "produto já cadastrado na base de dados.";
                    }
                }
                else
                {
                    return "PRoduto inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string UpdateProd(Produto prd)
        {
            try
            {
                if (prd != null)
                {
                    _contexto.Update(prd);
                    _contexto.SaveChanges();

                    return "Produto alterado com sucesso!";
                }
                else
                {
                    return "Produto inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public Produto GetProdByCod(int codigo)
        {
            Produto primeiroUsuario = new Produto();

            try
            {
                if (codigo == 0)
                {
                    return null;
                }

                var produto = _contexto.Produto.Where(x => x.CodProd == codigo).ToList();
                primeiroUsuario = produto.FirstOrDefault();

                if (primeiroUsuario != null)
                {
                    return primeiroUsuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Produto> GetAllPRoducts()
        {
            List<Produto> lstPrd = new List<Produto>();
            try
            {

                lstPrd = _contexto.Produto.Select(x => x).ToList();

                if (lstPrd != null)
                {
                    return lstPrd;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string DeletePRodByCod(int codigo)
        {
            try
            {
                if (codigo == 0)
                {
                    return "Produto inválido! Por favor tente novamente.";
                }
                else
                {
                    var prd = GetProdByCod(codigo);

                    if (prd != null)
                    {
                        _contexto.Produto.Remove(prd);
                        _contexto.SaveChanges();

                        return "Produto " + prd.CodProd + " deletado com sucesso!";
                    }
                    else
                    {
                        return "Produto não cadastrado!";
                    }
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

    }
}
