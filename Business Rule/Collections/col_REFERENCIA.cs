using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_REFERENCIA
	/// Esta classe representa uma lista de objetos da tabela REFERENCIA (representados pela classe rul_REFERENCIA) no banco de dados
	/// 
	/// </summary>
	public class col_REFERENCIA : System.Collections.CollectionBase 
	{
		public col_REFERENCIA()
		{
		}
		public col_REFERENCIA( int par_REFERENCIA)
		{
			rul_REFERENCIA REFERENCIA = new rul_REFERENCIA();


			REFERENCIA.REFERENCIA = par_REFERENCIA;
 

			col_REFERENCIA lista = REFERENCIA.GetAll();
				
			foreach (rul_REFERENCIA item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_REFERENCIA item)
		{
			List.Add( item);
		}

		public void Remove (rul_REFERENCIA item)
		{
			List.Remove(item);
		}

		public int Find(rul_REFERENCIA item)
		{
			return List.IndexOf(item);
		}

		public rul_REFERENCIA Item(int index)
		{
			return (rul_REFERENCIA) List[index];
		}
	}
}