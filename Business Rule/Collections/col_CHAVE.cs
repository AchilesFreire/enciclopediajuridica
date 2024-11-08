using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_CHAVE
	/// Esta classe representa uma lista de objetos da tabela CHAVE (representados pela classe rul_CHAVE) no banco de dados
	/// 
	/// </summary>
	public class col_CHAVE : System.Collections.CollectionBase 
	{
		public col_CHAVE()
		{
		}
		public col_CHAVE( int par_CHAVE)
		{
			rul_CHAVE CHAVE = new rul_CHAVE();


			CHAVE.CHAVE = par_CHAVE;
 

			col_CHAVE lista = CHAVE.GetAll();
				
			foreach (rul_CHAVE item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_CHAVE item)
		{
			List.Add( item);
		}

		public void Remove (rul_CHAVE item)
		{
			List.Remove(item);
		}

		public int Find(rul_CHAVE item)
		{
			return List.IndexOf(item);
		}

		public rul_CHAVE Item(int index)
		{
			return (rul_CHAVE) List[index];
		}
	}
}