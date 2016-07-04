using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_BO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //criei uma instância da classe AlunoBLL
            AlunoBLL _aluno = new AlunoBLL();
            //estou usando o método getAlunos e retornando uma lista de alunos

            List<Aluno> alunos = _aluno.getAlunos().ToList();
            //passando para view
            return View(alunos);
        }

        // GET: Home
        public ActionResult ListaAlunos()
        {
            //criei uma instância da classe AlunoBLL
            AlunoBLL _aluno = new AlunoBLL();
            //estou usando o método getAlunos e retornando uma lista de alunos

            List<Aluno> alunos = _aluno.getAlunos().ToList();
            //passando para view
            return View(alunos);
        }


        // GET
        [ActionName("Create")]
        public ActionResult Create_Get()
        {

            return View();
        }


        //metado assinatura diferente

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {

            if (ModelState.IsValid)
            {
                Aluno aluno = new Aluno();
                //UpdateModel(aluno);//Varre o forumlario submetido criando objeto
                //TryUpdateModel() nao lança exeção
                AlunoBLL alunobll = new AlunoBLL();
                alunobll.IncluirAluno(aluno);
                //direciona action index

                return RedirectToAction("Index");
            }
            return View();
        }

        //get
        public ActionResult Edit(int id)
        {
            AlunoBLL alunobll = new AlunoBLL();
            Aluno aluno = alunobll.getAlunos().Single(x => x.Id == id);

            return View(aluno);
        }

        //Metado modo bind
        [HttpPost]//PostFormulario Sumbmit
        [ActionName("Edit")]
        public ActionResult Edit_Post([Bind(Include = "id,Email,DataNascimento, Sexo")]Aluno aluno)
        {
            AlunoBLL alunobll = new AlunoBLL();
            aluno.Nome = alunobll.getAlunos().Single(x => x.Id == aluno.Id).Nome;
            //podendo ser alterado o expecificado
            //UpdateModel(aluno, includeProperties: new[] { "Nome", "Email", "DataNascimento", "Sexo" });

            if (ModelState.IsValid)
            {
                alunobll.AtualizaAluno(aluno);
                return RedirectToAction("index");
            }
            //caso ocorra erro volta para view edit
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            //Metado Delete via bind
            AlunoBLL alunobll = new AlunoBLL();
            //Aluno aluno = alunobll.getAlunos().Single(x => x.Id == id);
            alunobll.DeleteAluno(id);
            //return View(aluno);
            //aluno.DeleteAluno(id);
            return RedirectToAction("Index");

        }


        //Get
        public ActionResult Detalhe(int Id)
        {
            AlunoBLL alunobll = new AlunoBLL();
            Aluno aluno = alunobll.getAlunos().Single(x => x.Id == Id);
            return View(aluno);

        }

        public ActionResult Procurar(string ProcurarPor, string Criterio)
        {
            AlunoBLL alunobll = new AlunoBLL();
            if (ProcurarPor == "Email")
            {
                Aluno aluno = alunobll.getAlunos().SingleOrDefault(x => x.Email == Criterio || Criterio == null);
                return View(aluno);

            }
            else
            {

                Aluno aluno = alunobll.getAlunos().SingleOrDefault(x => x.Nome == Criterio || Criterio == null);
                return View(aluno);
            }
        }


      
    }

}