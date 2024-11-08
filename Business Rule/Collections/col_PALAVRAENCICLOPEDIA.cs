using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_PALAVRAENCICLOPEDIA
	/// Esta classe representa uma lista de objetos da tabela PALAVRAENCICLOPEDIA (representados pela classe rul_PALAVRAENCICLOPEDIA) no banco de dados
	/// 
	/// </summary>
	public class col_PALAVRAENCICLOPEDIA : System.Collections.CollectionBase 
	{
		public col_PALAVRAENCICLOPEDIA()
		{
		}
		public col_PALAVRAENCICLOPEDIA( int par_PALAVRAENCICLOPEDIA)
		{
			rul_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new rul_PALAVRAENCICLOPEDIA();


			PALAVRAENCICLOPEDIA.PALAVRAENCICLOPEDIA = par_PALAVRAENCICLOPEDIA;
 

			col_PALAVRAENCICLOPEDIA lista = PALAVRAENCICLOPEDIA.GetAll();
				
			foreach (rul_PALAVRAENCICLOPEDIA item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_PALAVRAENCICLOPEDIA item)
		{
			List.Add( item);
		}

		public void Remove (rul_PALAVRAENCICLOPEDIA item)
		{
			List.Remove(item);
		}

		public int Find(rul_PALAVRAENCICLOPEDIA item)
		{
			return List.IndexOf(item);
		}

		public rul_PALAVRAENCICLOPEDIA Item(int index)
		{
			return (rul_PALAVRAENCICLOPEDIA) List[index];
		}
	}
}