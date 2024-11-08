using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_CHAVEVERBETE
	/// Esta classe representa uma lista de objetos da tabela CHAVEVERBETE (representados pela classe rul_CHAVEVERBETE) no banco de dados
	/// 
	/// </summary>
	public class col_CHAVEVERBETE : System.Collections.CollectionBase 
	{
		public col_CHAVEVERBETE()
		{
		}
		public col_CHAVEVERBETE( int par_CHAVE,  int par_VERBETE)
		{
			rul_CHAVEVERBETE CHAVEVERBETE = new rul_CHAVEVERBETE();


			CHAVEVERBETE.CHAVE = par_CHAVE;
 			CHAVEVERBETE.VERBETE = par_VERBETE;
 

			col_CHAVEVERBETE lista = CHAVEVERBETE.GetAll();
				
			foreach (rul_CHAVEVERBETE item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_CHAVEVERBETE item)
		{
			List.Add( item);
		}

		public void Remove (rul_CHAVEVERBETE item)
		{
			List.Remove(item);
		}

		public int Find(rul_CHAVEVERBETE item)
		{
			return List.IndexOf(item);
		}

		public rul_CHAVEVERBETE Item(int index)
		{
			return (rul_CHAVEVERBETE) List[index];
		}
	}
}