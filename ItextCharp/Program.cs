using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ExemploPDF
{
	class Program
	{
		static void Main(string[] args)
		{
			// Criar um novo documento PDF
			Document doc = new Document();

			try
			{
				// Definir o nome do arquivo PDF
				string outputFilePath = @"C:\Users\Escolar Manager\Documents\pdf" + "Test.pdf";

				// Criar um escritor para o documento PDF
				PdfWriter.GetInstance(doc, new FileStream(outputFilePath, FileMode.Create));

				// Abrir o documento para escrita
				doc.Open();

				// Adicionar um título ao documento
				Paragraph title = new Paragraph("Lista de Funcionários\n\n",
					FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
				title.Alignment = Element.ALIGN_CENTER;
				doc.Add(title);

				// Criar uma tabela com 3 colunas
				PdfPTable table = new PdfPTable(3);
				table.WidthPercentage = 100;

				// Adicionar cabeçalhos da tabela
				table.AddCell("Nome");
				table.AddCell("Cargo");
				table.AddCell("Salário");

				// Adicionar linhas com os dados dos funcionários
				AdicionarFuncionario(table, "João Silva", "Desenvolvedor", 5000);
				AdicionarFuncionario(table, "Maria Souza", "Gerente de Projetos", 8000);
				AdicionarFuncionario(table, "Carlos Santos", "Analista de Qualidade", 4500);

				// Adicionar a tabela ao documento
				doc.Add(table);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ocorreu um erro: " + ex.Message);
			}
			finally
			{
				// Fechar o documento
				doc.Close();
			}
		}

		static void AdicionarFuncionario(PdfPTable table, string nome, string cargo, float salario)
		{
			table.AddCell(nome);
			table.AddCell(cargo);
			table.AddCell(salario.ToString("C")); // Formatar o salário como moeda
		}
	}
}