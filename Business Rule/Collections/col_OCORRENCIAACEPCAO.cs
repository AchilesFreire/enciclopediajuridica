using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_OCORRENCIAACEPCAO
	/// Esta classe representa uma lista de objetos da tabela OCORRENCIAACEPCAO (representados pela classe rul_OCORRENCIAACEPCAO) no banco de dados
	/// 
	/// </summary>
	public class col_OCORRENCIAACEPCAO : System.Collections.CollectionBase 
	{
		public col_OCORRENCIAACEPCAO()
		{
		}
		public col_OCORRENCIAACEPCAO( int par_ACEPCAO)
		{
			rul_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new rul_OCORRENCIAACEPCAO();


			OCORRENCIAACEPCAO.ACEPCAO = par_ACEPCAO;
 

			col_OCORRENCIAACEPCAO lista = OCORRENCIAACEPCAO.GetAll();
				
			foreach (rul_OCORRENCIAACEPCAO item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_OCORRENCIAACEPCAO item)
		{
			List.Add( item);
		}

		public void Remove (rul_OCORRENCIAACEPCAO item)
		{
			List.Remove(item);
		}

		public int Find(rul_OCORRENCIAACEPCAO item)
		{
			return List.IndexOf(item);
		}

		public rul_OCORRENCIAACEPCAO Item(int index)
		{
			return (rul_OCORRENCIAACEPCAO) List[index];
		}
	}
}