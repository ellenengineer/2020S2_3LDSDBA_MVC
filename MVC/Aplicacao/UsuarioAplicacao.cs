using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC
{
    public class UsuarioAplicacao
    {
        private INFONEWContext _contexto;

        public UsuarioAplicacao(INFONEWContext contexto)
        {
            _contexto = contexto;
        }

        public string InsertUser(Login usuario)
        {
            try
            {
                if (usuario != null)
                {
                    var usuarioExiste = GetUserByLogin(usuario.Login1);

                    if (usuarioExiste == null)
                    {
                        _contexto.Add(usuario);
                        _contexto.SaveChanges();

                        return "Usuário cadastrado com sucesso!";
                    }
                    else
                    {
                        return "login já cadastrado na base de dados.";
                    }
                }
                else
                {
                    return "Usuário inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string UpdateUser(Login usuario)
        {
            try
            {
                if (usuario != null)
                {
                    _contexto.Update(usuario);
                    _contexto.SaveChanges();

                    return "Usuário alterado com sucesso!";
                }
                else
                {
                    return "Usuário inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public Login GetUserByLogin(string login)
        {
            Login primeiroUsuario = new Login();

            try
            {
                if (login == string.Empty)
                {
                    return null;
                }

                var cliente = _contexto.Login.Where(x => x.Login1 == login).ToList();
                primeiroUsuario = cliente.FirstOrDefault();

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

        public List<Login> GetAllUsers()
        {
            List<Login> listaDeUsuarios = new List<Login>();
            try
            {

                listaDeUsuarios = _contexto.Login.Select(x => x).ToList();

                if (listaDeUsuarios != null)
                {
                    return listaDeUsuarios;
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

        public string DeleteUserByEmail(string login)
        {
            try
            {
                if (login == string.Empty)
                {
                    return "Login inválido! Por favor tente novamente.";
                }
                else
                {
                    var usuario = GetUserByLogin(login);

                    if (usuario != null)
                    {
                        _contexto.Login.Remove(usuario);
                        _contexto.SaveChanges();

                        return "Usuário " + usuario.Login1 + " deletado com sucesso!";
                    }
                    else
                    {
                        return "Usuário não cadastrado!";
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
