using System;
using System.Collections.Generic;
using System.IO;
using ProjetoInstaDev.Interfaces;

namespace ProjetoInstaDev.Models
{
    public class Post : Instadev_Base, IPost
    {
        public Post(int id, string legenda, string imagem, Usuario enviadoPor)
        {
            this.Id = id;
            this.Legenda = legenda;
            this.Imagem = imagem;
            this.EnviadoPor = enviadoPor;

        }
        private int Id { get; set; }

        public string Legenda { get; set; }

        public string Imagem { get; set; }

        public Usuario EnviadoPor { get; set; }
        public string nomeEnviado { get; set; }
        public string fotoEnviado;

        private const string CAMINHO = "Database/Post.csv";

        public Post()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        public int PegarId()
        {
            return Id;
        }
        public List<int> RetornarIds()
        {
            List<int> Ids = new List<int>();
            foreach (var item in ListarFeed())
            {
                Ids.Add(item.Id);
            }
            return Ids;
        }
        public void SetarId()
        {
            Id = GerarId(RetornarIds());
        }
        public string Preparar(Post p)
        {
            return $"{p.Id};{p.Legenda};{p.Imagem};{p.nomeEnviado};{p.fotoEnviado}";
        }

        public void Criar(Post p)
        {
            string[] post = { Preparar(p) };

            File.AppendAllLines(CAMINHO, post);
        }

        public List<Post> ListarFeed()
        {
            List<Post> posts = new List<Post>();

            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Post post = new Post();

                post.Id = Int32.Parse(linha[0]);
                post.Legenda = linha[1];
                post.Imagem = linha[2];
                post.nomeEnviado = linha[3];
                post.fotoEnviado = linha[4];
                posts.Add(post);
            }
            posts.Reverse();
            return posts;
        }

        public List<Post> ListarPerfil(string Logado)
        {
            List<Post> PostsPerfil = new List<Post>();

            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {

                string[] linha = item.Split(";");

                if (linha[3] != null)
                {

                    if (Logado == linha[3])
                    {
                        Post post = new Post();

                        post.Id = Int32.Parse(linha[0]);
                        post.Legenda = linha[1];
                        post.Imagem = linha[2];
                        post.nomeEnviado = linha[3];
                        PostsPerfil.Add(post);
                    }
                }


            }
            return PostsPerfil;
        }


    }
}