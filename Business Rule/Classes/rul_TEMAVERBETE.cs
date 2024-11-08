using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;


namespace EnciclopediaJuridica.BusinessRule
{
	public class rul_TEMAVERBETE
	{

		#region "Variaveis" 

			private  int _TEMAVERBETE = -1;
			private  int _TEMA = -1;
			private  int _VERBETE = -1;


			private String _mensagem = "";
			private Boolean _NovoRegistro = true;

		#endregion

		#region "Construtures"
 
		public rul_TEMAVERBETE()
		{
		}
		public rul_TEMAVERBETE( int par_TEMAVERBETE)
		{
			try
				{
					this.TEMAVERBETE = par_TEMAVERBETE;
 
					this.NovoRegistro = !this.Load();
				}
			catch(Exception ex)
				{
					this.mensagem = ex.Message;
				}

		}

		#endregion

		#region "Propriedades"
 
			public  int TEMAVERBETE
			{
				get {return _TEMAVERBETE;}
				set {_TEMAVERBETE = value;}
			}

			public  int TEMA
			{
				get {return _TEMA;}
				set {_TEMA = value;}
			}

			public  int VERBETE
			{
				get {return _VERBETE;}
				set {_VERBETE = value;}
			}





			public String mensagem
			{
				get { return _mensagem; }
				set { _mensagem = value; }
			}
	
			public Boolean NovoRegistro
			{
				get { return _NovoRegistro; }
				set { _NovoRegistro = value;  }
			}

		#endregion

		#region "Metodos Publicos" 

		public Boolean ValidateInsert()
		{
			try
			{
				// Validacao para o insert e o update
				if (! Validate())
					return false;
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();
				
				TEMAVERBETE.TEMAVERBETE = this.TEMAVERBETE;
				TEMAVERBETE.TEMA = this.TEMA;
				TEMAVERBETE.VERBETE = this.VERBETE;

				this.mensagem="";

				Boolean retorno = TEMAVERBETE.Insert();

				this.mensagem = TEMAVERBETE.mensagem;

				return retorno;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateUpdate()
		{
			try
			{
				// Validacao para o insert e o update
				if (! Validate())
					return false;
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();
				
				TEMAVERBETE.TEMAVERBETE = this.TEMAVERBETE;
				TEMAVERBETE.TEMA = this.TEMA;
				TEMAVERBETE.VERBETE = this.VERBETE;

				this.mensagem= "";
				
				Boolean retorno = TEMAVERBETE.Update();

				this.mensagem = TEMAVERBETE.mensagem;

				return retorno;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean Validate()
		{
			try
			{

				if (  this.TEMA == -1)
				{
					this.mensagem = "O Campo TEMA tem que ser preenchido com Inteiro";
					return false;
				}
				if (  this.VERBETE == -1)
				{
					this.mensagem = "O Campo VERBETE tem que ser preenchido com Inteiro";
					return false;
				}


				return true;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateDelete()
		{
			try
			{
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();

				
				TEMAVERBETE.TEMAVERBETE = this.TEMAVERBETE;
				TEMAVERBETE.TEMA = this.TEMA;
				TEMAVERBETE.VERBETE = this.VERBETE;


				if (VerifyForeignKeys())
					{

						this.mensagem= "";
				
						Boolean retorno = TEMAVERBETE.Delete();

						this.mensagem = TEMAVERBETE.mensagem;

						return retorno;
					}	
				else
					{
						return false;
					}

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateDeleteMasterDetail()
		{
			try
			{
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();
				

				this.mensagem= "";
				
				Boolean retorno = TEMAVERBETE.DeleteMasterDetail();

				this.mensagem = TEMAVERBETE.mensagem;

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public col_TEMAVERBETE GetAll()
		{
			try
			{
				cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();
				col_TEMAVERBETE colecao = new col_TEMAVERBETE();
				
				TEMAVERBETE.TEMAVERBETE = this.TEMAVERBETE;
				TEMAVERBETE.TEMA = this.TEMA;
				TEMAVERBETE.VERBETE = this.VERBETE;

				System.Data.DataSet ds = TEMAVERBETE.GetAll();

                		if (TEMAVERBETE.mensagem != String.Empty)
		                {
		                    this.mensagem = TEMAVERBETE.mensagem;
		                    return null;
		                }

				for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
				{
					rul_TEMAVERBETE item = new rul_TEMAVERBETE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.TEMAVERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.TEMA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2]);


					item.NovoRegistro = false;
					colecao.Add(item);
				}
				
				return colecao;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public System.Data.DataSet GetAllInDataSet()
		{
			try
			{
				cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();			
				
				TEMAVERBETE.TEMAVERBETE = this.TEMAVERBETE;
				TEMAVERBETE.TEMA = this.TEMA;
				TEMAVERBETE.VERBETE = this.VERBETE;

				System.Data.DataSet ds = TEMAVERBETE.GetAll();

				this.mensagem = TEMAVERBETE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public col_TEMAVERBETE FindAll()
		{

			cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();
			col_TEMAVERBETE colecao = new col_TEMAVERBETE();
				
				TEMAVERBETE.TEMAVERBETE = this.TEMAVERBETE;
				TEMAVERBETE.TEMA = this.TEMA;
				TEMAVERBETE.VERBETE = this.VERBETE;

			System.Data.DataSet ds = TEMAVERBETE.FindAll();

               		if (TEMAVERBETE.mensagem != String.Empty)
	                {
	                    this.mensagem = TEMAVERBETE.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_TEMAVERBETE item = new rul_TEMAVERBETE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.TEMAVERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.TEMA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2]);


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}


		public col_TEMAVERBETE FindAllGrid()
		{

			cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();
			col_TEMAVERBETE colecao = new col_TEMAVERBETE();
				
				TEMAVERBETE.TEMAVERBETE = this.TEMAVERBETE;
				TEMAVERBETE.TEMA = this.TEMA;
				TEMAVERBETE.VERBETE = this.VERBETE;

			System.Data.DataSet ds = TEMAVERBETE.FindAllGrid();

               		if (TEMAVERBETE.mensagem != String.Empty)
	                {
	                    this.mensagem = TEMAVERBETE.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_TEMAVERBETE item = new rul_TEMAVERBETE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.TEMAVERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.TEMA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2]);


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public System.Data.DataSet FindAllInDataSet()
		{
			try
			{
				cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();			
				
				TEMAVERBETE.TEMAVERBETE = this.TEMAVERBETE;
				TEMAVERBETE.TEMA = this.TEMA;
				TEMAVERBETE.VERBETE = this.VERBETE;

				System.Data.DataSet ds = TEMAVERBETE.FindAll();

				this.mensagem = TEMAVERBETE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public System.Data.DataSet GetAllMasterDetail()
		{
			try
			{
				cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();			
				

				System.Data.DataSet ds = TEMAVERBETE.GetAllMasterDetail();

				this.mensagem = TEMAVERBETE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public Boolean Load()
		{
			try
			{
				cls_TEMAVERBETE TEMAVERBETE = new cls_TEMAVERBETE();


				
				TEMAVERBETE.TEMAVERBETE = this.TEMAVERBETE;


				System.Data.DataSet ds = TEMAVERBETE.Load();


                		if (TEMAVERBETE.mensagem != String.Empty)
		                {
		                    this.mensagem = TEMAVERBETE.mensagem;
		                    return false;
		                }


				if( ds.Tables[0].Rows.Count ==1)
				{
										if( ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
						this.TEMAVERBETE = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

					if( ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
						this.TEMA = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[1]);

					if( ds.Tables[0].Rows[0].ItemArray[2].ToString() != String.Empty)
						this.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[2]);


					this.NovoRegistro = false;
					return true;
				}
				else
				{
					this.mensagem = "Load retornou mais de uma linha";
					this.NovoRegistro = true;
					return false;
				}

			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return false;
			}
		}

		#endregion

		#region "Metodos Privados"

		private Boolean VerifyForeignKeys()
		{
			try
			{
				
				Boolean retorno = true;

				

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		#endregion
	}
}