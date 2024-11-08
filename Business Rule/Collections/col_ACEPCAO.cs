using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_ACEPCAO
	/// Esta classe representa uma lista de objetos da tabela ACEPCAO (representados pela classe rul_ACEPCAO) no banco de dados
	/// 
	/// </summary>
	public class col_ACEPCAO : System.Collections.CollectionBase 
	{
		public col_ACEPCAO()
		{
		}
		public col_ACEPCAO( int par_ACEPCAO)
		{
			rul_ACEPCAO ACEPCAO = new rul_ACEPCAO();


			ACEPCAO.ACEPCAO = par_ACEPCAO;
 

			col_ACEPCAO lista = ACEPCAO.GetAll();
				
			foreach (rul_ACEPCAO item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_ACEPCAO item)
		{
			List.Add( item);
		}

		public void Remove (rul_ACEPCAO item)
		{
			List.Remove(item);
		}

		public int Find(rul_ACEPCAO item)
		{
			return List.IndexOf(item);
		}

		public rul_ACEPCAO Item(int index)
		{
			return (rul_ACEPCAO) List[index];
		}
	}
}