using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_TEMA
	/// Esta classe representa uma lista de objetos da tabela TEMA (representados pela classe rul_TEMA) no banco de dados
	/// 
	/// </summary>
	public class col_TEMA : System.Collections.CollectionBase 
	{
		public col_TEMA()
		{
		}
		public col_TEMA( int par_TEMA)
		{
			rul_TEMA TEMA = new rul_TEMA();


			TEMA.TEMA = par_TEMA;
 

			col_TEMA lista = TEMA.GetAll();
				
			foreach (rul_TEMA item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_TEMA item)
		{
			List.Add( item);
		}

		public void Remove (rul_TEMA item)
		{
			List.Remove(item);
		}

		public int Find(rul_TEMA item)
		{
			return List.IndexOf(item);
		}

		public rul_TEMA Item(int index)
		{
			return (rul_TEMA) List[index];
		}
	}
}