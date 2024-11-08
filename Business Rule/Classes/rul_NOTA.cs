using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;


namespace EnciclopediaJuridica.BusinessRule
{
	public class rul_NOTA
	{

		#region "Variaveis" 

			private  int _NOTA = -1;
			private  int _VERBETE = -1;
			private  String _DEFINICAO = String.Empty;


			private String _mensagem = "";
			private Boolean _NovoRegistro = true;

		#endregion

		#region "Construtures"
 
		public rul_NOTA()
		{
		}
		public rul_NOTA( int par_NOTA)
		{
			try
				{
					this.NOTA = par_NOTA;
 
					this.NovoRegistro = !this.Load();
				}
			catch(Exception ex)
				{
					this.mensagem = ex.Message;
				}

		}

		#endregion

		#region "Propriedades"
 
			public  int NOTA
			{
				get {return _NOTA;}
				set {_NOTA = value;}
			}

			public  int VERBETE
			{
				get {return _VERBETE;}
				set {_VERBETE = value;}
			}

			public  String DEFINICAO
			{
				get {return _DEFINICAO;}
				set {_DEFINICAO = value;}
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
				cls_NOTA NOTA = new cls_NOTA();
				
				NOTA.NOTA = this.NOTA;
				NOTA.VERBETE = this.VERBETE;
				NOTA.DEFINICAO = this.DEFINICAO;

				this.mensagem="";

				Boolean retorno = NOTA.Insert();

				this.mensagem = NOTA.mensagem;

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
				cls_NOTA NOTA = new cls_NOTA();
				
				NOTA.NOTA = this.NOTA;
				NOTA.VERBETE = this.VERBETE;
				NOTA.DEFINICAO = this.DEFINICAO;

				this.mensagem= "";
				
				Boolean retorno = NOTA.Update();

				this.mensagem = NOTA.mensagem;

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

				if (  this.VERBETE == -1)
				{
					this.mensagem = "O Campo VERBETE tem que ser preenchido com Inteiro";
					return false;
				}
				if (  this.DEFINICAO == String.Empty)
				{
					this.mensagem = "O Campo DEFINICAO tem que ser preenchido com Texto";
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
				cls_NOTA NOTA = new cls_NOTA();

				
				NOTA.NOTA = this.NOTA;
				NOTA.VERBETE = this.VERBETE;
				NOTA.DEFINICAO = this.DEFINICAO;


				if (VerifyForeignKeys())
					{

						this.mensagem= "";
				
						Boolean retorno = NOTA.Delete();

						this.mensagem = NOTA.mensagem;

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
				cls_NOTA NOTA = new cls_NOTA();
				

				this.mensagem= "";
				
				Boolean retorno = NOTA.DeleteMasterDetail();

				this.mensagem = NOTA.mensagem;

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public col_NOTA GetAll()
		{
			try
			{
				cls_NOTA NOTA = new cls_NOTA();
				col_NOTA colecao = new col_NOTA();
				
				NOTA.NOTA = this.NOTA;
				NOTA.VERBETE = this.VERBETE;
				NOTA.DEFINICAO = this.DEFINICAO;

				System.Data.DataSet ds = NOTA.GetAll();

                		if (NOTA.mensagem != String.Empty)
		                {
		                    this.mensagem = NOTA.mensagem;
		                    return null;
		                }

				for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
				{
					rul_NOTA item = new rul_NOTA();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.NOTA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();


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
				cls_NOTA NOTA = new cls_NOTA();			
				
				NOTA.NOTA = this.NOTA;
				NOTA.VERBETE = this.VERBETE;
				NOTA.DEFINICAO = this.DEFINICAO;

				System.Data.DataSet ds = NOTA.GetAll();

				this.mensagem = NOTA.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public col_NOTA FindAll()
		{

			cls_NOTA NOTA = new cls_NOTA();
			col_NOTA colecao = new col_NOTA();
				
				NOTA.NOTA = this.NOTA;
				NOTA.VERBETE = this.VERBETE;
				NOTA.DEFINICAO = this.DEFINICAO;

			System.Data.DataSet ds = NOTA.FindAll();

               		if (NOTA.mensagem != String.Empty)
	                {
	                    this.mensagem = NOTA.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_NOTA item = new rul_NOTA();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.NOTA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}


		public col_NOTA FindAllGrid()
		{

			cls_NOTA NOTA = new cls_NOTA();
			col_NOTA colecao = new col_NOTA();
				
				NOTA.NOTA = this.NOTA;
				NOTA.VERBETE = this.VERBETE;
				NOTA.DEFINICAO = this.DEFINICAO;

			System.Data.DataSet ds = NOTA.FindAllGrid();

               		if (NOTA.mensagem != String.Empty)
	                {
	                    this.mensagem = NOTA.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_NOTA item = new rul_NOTA();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.NOTA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public System.Data.DataSet FindAllInDataSet()
		{
			try
			{
				cls_NOTA NOTA = new cls_NOTA();			
				
				NOTA.NOTA = this.NOTA;
				NOTA.VERBETE = this.VERBETE;
				NOTA.DEFINICAO = this.DEFINICAO;

				System.Data.DataSet ds = NOTA.FindAll();

				this.mensagem = NOTA.mensagem;

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
				cls_NOTA NOTA = new cls_NOTA();			
				

				System.Data.DataSet ds = NOTA.GetAllMasterDetail();

				this.mensagem = NOTA.mensagem;

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
				cls_NOTA NOTA = new cls_NOTA();


				
				NOTA.NOTA = this.NOTA;


				System.Data.DataSet ds = NOTA.Load();


                		if (NOTA.mensagem != String.Empty)
		                {
		                    this.mensagem = NOTA.mensagem;
		                    return false;
		                }


				if( ds.Tables[0].Rows.Count ==1)
				{
										if( ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
						this.NOTA = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

					if( ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
						this.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[1]);

					if( ds.Tables[0].Rows[0].ItemArray[2].ToString() != String.Empty)
						this.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[2]);


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