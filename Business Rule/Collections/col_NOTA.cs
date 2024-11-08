using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_NOTA
	/// Esta classe representa uma lista de objetos da tabela NOTA (representados pela classe rul_NOTA) no banco de dados
	/// 
	/// </summary>
	public class col_NOTA : System.Collections.CollectionBase 
	{
		public col_NOTA()
		{
		}
		public col_NOTA( int par_NOTA)
		{
			rul_NOTA NOTA = new rul_NOTA();


			NOTA.NOTA = par_NOTA;
 

			col_NOTA lista = NOTA.GetAll();
				
			foreach (rul_NOTA item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_NOTA item)
		{
			List.Add( item);
		}

		public void Remove (rul_NOTA item)
		{
			List.Remove(item);
		}

		public int Find(rul_NOTA item)
		{
			return List.IndexOf(item);
		}

		public rul_NOTA Item(int index)
		{
			return (rul_NOTA) List[index];
		}
	}
}