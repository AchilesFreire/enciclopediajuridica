using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_VERBETE
	/// Esta classe representa uma lista de objetos da tabela VERBETE (representados pela classe rul_VERBETE) no banco de dados
	/// 
	/// </summary>
	public class col_VERBETE : System.Collections.CollectionBase 
	{
		public col_VERBETE()
		{
		}
		public col_VERBETE( int par_VERBETE)
		{
			rul_VERBETE VERBETE = new rul_VERBETE();


			VERBETE.VERBETE = par_VERBETE;
 

			col_VERBETE lista = VERBETE.GetAll();
				
			foreach (rul_VERBETE item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_VERBETE item)
		{
			List.Add( item);
		}

		public void Remove (rul_VERBETE item)
		{
			List.Remove(item);
		}

		public int Find(rul_VERBETE item)
		{
			return List.IndexOf(item);
		}

		public rul_VERBETE Item(int index)
		{
			return (rul_VERBETE) List[index];
		}
	}
}