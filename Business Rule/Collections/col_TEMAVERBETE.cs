using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_TEMAVERBETE
	/// Esta classe representa uma lista de objetos da tabela TEMAVERBETE (representados pela classe rul_TEMAVERBETE) no banco de dados
	/// 
	/// </summary>
	public class col_TEMAVERBETE : System.Collections.CollectionBase 
	{
		public col_TEMAVERBETE()
		{
		}
		public col_TEMAVERBETE( int par_TEMAVERBETE)
		{
			rul_TEMAVERBETE TEMAVERBETE = new rul_TEMAVERBETE();


			TEMAVERBETE.TEMAVERBETE = par_TEMAVERBETE;
 

			col_TEMAVERBETE lista = TEMAVERBETE.GetAll();
				
			foreach (rul_TEMAVERBETE item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_TEMAVERBETE item)
		{
			List.Add( item);
		}

		public void Remove (rul_TEMAVERBETE item)
		{
			List.Remove(item);
		}

		public int Find(rul_TEMAVERBETE item)
		{
			return List.IndexOf(item);
		}

		public rul_TEMAVERBETE Item(int index)
		{
			return (rul_TEMAVERBETE) List[index];
		}
	}
}