using System;
using EnciclopediaJuridica.BusinessRule;

namespace EnciclopediaJuridica.BusinessCollection
{  
	/// <summary>
	/// Definicao da collection col_VERBETEUSUARIO
	/// Esta classe representa uma lista de objetos da tabela VERBETEUSUARIO (representados pela classe rul_VERBETEUSUARIO) no banco de dados
	/// 
	/// </summary>
	public class col_VERBETEUSUARIO : System.Collections.CollectionBase 
	{
		public col_VERBETEUSUARIO()
		{
		}
		public col_VERBETEUSUARIO( int par_VERBETEUSUARIO)
		{
			rul_VERBETEUSUARIO VERBETEUSUARIO = new rul_VERBETEUSUARIO();


			VERBETEUSUARIO.VERBETEUSUARIO = par_VERBETEUSUARIO;
 

			col_VERBETEUSUARIO lista = VERBETEUSUARIO.GetAll();
				
			foreach (rul_VERBETEUSUARIO item in lista)
			{
				this.Add(item);
			}

		}

		public void Add (rul_VERBETEUSUARIO item)
		{
			List.Add( item);
		}

		public void Remove (rul_VERBETEUSUARIO item)
		{
			List.Remove(item);
		}

		public int Find(rul_VERBETEUSUARIO item)
		{
			return List.IndexOf(item);
		}

		public rul_VERBETEUSUARIO Item(int index)
		{
			return (rul_VERBETEUSUARIO) List[index];
		}
	}
}