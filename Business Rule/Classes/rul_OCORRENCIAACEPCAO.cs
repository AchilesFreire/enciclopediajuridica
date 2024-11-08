using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;


namespace EnciclopediaJuridica.BusinessRule
{
	public class rul_OCORRENCIAACEPCAO
	{

		#region "Variaveis" 

			private  int _ACEPCAO = -1;
			private  String _PALAVRAS = String.Empty;


			private String _mensagem = "";
			private Boolean _NovoRegistro = true;

		#endregion

		#region "Construtures"
 
		public rul_OCORRENCIAACEPCAO()
		{
		}
		public rul_OCORRENCIAACEPCAO( int par_ACEPCAO)
		{
			try
				{
					this.ACEPCAO = par_ACEPCAO;
 
					this.NovoRegistro = !this.Load();
				}
			catch(Exception ex)
				{
					this.mensagem = ex.Message;
				}

		}

		#endregion

		#region "Propriedades"
 
			public  int ACEPCAO
			{
				get {return _ACEPCAO;}
				set {_ACEPCAO = value;}
			}

			public  String PALAVRAS
			{
				get {return _PALAVRAS;}
				set {_PALAVRAS = value;}
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
				cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();
				
				OCORRENCIAACEPCAO.ACEPCAO = this.ACEPCAO;
				OCORRENCIAACEPCAO.PALAVRAS = this.PALAVRAS;

				this.mensagem="";

				Boolean retorno = OCORRENCIAACEPCAO.Insert();

				this.mensagem = OCORRENCIAACEPCAO.mensagem;

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
				cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();
				
				OCORRENCIAACEPCAO.ACEPCAO = this.ACEPCAO;
				OCORRENCIAACEPCAO.PALAVRAS = this.PALAVRAS;

				this.mensagem= "";
				
				Boolean retorno = OCORRENCIAACEPCAO.Update();

				this.mensagem = OCORRENCIAACEPCAO.mensagem;

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

				if (  this.PALAVRAS == String.Empty)
				{
					this.mensagem = "O Campo PALAVRAS tem que ser preenchido com Texto";
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
				cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();

				
				OCORRENCIAACEPCAO.ACEPCAO = this.ACEPCAO;
				OCORRENCIAACEPCAO.PALAVRAS = this.PALAVRAS;


				if (VerifyForeignKeys())
					{

						this.mensagem= "";
				
						Boolean retorno = OCORRENCIAACEPCAO.Delete();

						this.mensagem = OCORRENCIAACEPCAO.mensagem;

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
				cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();
				

				this.mensagem= "";
				
				Boolean retorno = OCORRENCIAACEPCAO.DeleteMasterDetail();

				this.mensagem = OCORRENCIAACEPCAO.mensagem;

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public col_OCORRENCIAACEPCAO GetAll()
		{
			try
			{
				cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();
				col_OCORRENCIAACEPCAO colecao = new col_OCORRENCIAACEPCAO();
				
				OCORRENCIAACEPCAO.ACEPCAO = this.ACEPCAO;
				OCORRENCIAACEPCAO.PALAVRAS = this.PALAVRAS;

				System.Data.DataSet ds = OCORRENCIAACEPCAO.GetAll();

                		if (OCORRENCIAACEPCAO.mensagem != String.Empty)
		                {
		                    this.mensagem = OCORRENCIAACEPCAO.mensagem;
		                    return null;
		                }

				for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
				{
					rul_OCORRENCIAACEPCAO item = new rul_OCORRENCIAACEPCAO();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.ACEPCAO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.PALAVRAS = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();


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
				cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();			
				
				OCORRENCIAACEPCAO.ACEPCAO = this.ACEPCAO;
				OCORRENCIAACEPCAO.PALAVRAS = this.PALAVRAS;

				System.Data.DataSet ds = OCORRENCIAACEPCAO.GetAll();

				this.mensagem = OCORRENCIAACEPCAO.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public col_OCORRENCIAACEPCAO FindAll()
		{

			cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();
			col_OCORRENCIAACEPCAO colecao = new col_OCORRENCIAACEPCAO();
				
				OCORRENCIAACEPCAO.ACEPCAO = this.ACEPCAO;
				OCORRENCIAACEPCAO.PALAVRAS = this.PALAVRAS;

			System.Data.DataSet ds = OCORRENCIAACEPCAO.FindAll();

               		if (OCORRENCIAACEPCAO.mensagem != String.Empty)
	                {
	                    this.mensagem = OCORRENCIAACEPCAO.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_OCORRENCIAACEPCAO item = new rul_OCORRENCIAACEPCAO();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.ACEPCAO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.PALAVRAS = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}


		public col_OCORRENCIAACEPCAO FindAllGrid()
		{

			cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();
			col_OCORRENCIAACEPCAO colecao = new col_OCORRENCIAACEPCAO();
				
				OCORRENCIAACEPCAO.ACEPCAO = this.ACEPCAO;
				OCORRENCIAACEPCAO.PALAVRAS = this.PALAVRAS;

			System.Data.DataSet ds = OCORRENCIAACEPCAO.FindAllGrid();

               		if (OCORRENCIAACEPCAO.mensagem != String.Empty)
	                {
	                    this.mensagem = OCORRENCIAACEPCAO.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_OCORRENCIAACEPCAO item = new rul_OCORRENCIAACEPCAO();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.ACEPCAO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.PALAVRAS = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public System.Data.DataSet FindAllInDataSet()
		{
			try
			{
				cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();			
				
				OCORRENCIAACEPCAO.ACEPCAO = this.ACEPCAO;
				OCORRENCIAACEPCAO.PALAVRAS = this.PALAVRAS;

				System.Data.DataSet ds = OCORRENCIAACEPCAO.FindAll();

				this.mensagem = OCORRENCIAACEPCAO.mensagem;

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
				cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();			
				

				System.Data.DataSet ds = OCORRENCIAACEPCAO.GetAllMasterDetail();

				this.mensagem = OCORRENCIAACEPCAO.mensagem;

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
				cls_OCORRENCIAACEPCAO OCORRENCIAACEPCAO = new cls_OCORRENCIAACEPCAO();


				
				OCORRENCIAACEPCAO.ACEPCAO = this.ACEPCAO;


				System.Data.DataSet ds = OCORRENCIAACEPCAO.Load();


                		if (OCORRENCIAACEPCAO.mensagem != String.Empty)
		                {
		                    this.mensagem = OCORRENCIAACEPCAO.mensagem;
		                    return false;
		                }


				if( ds.Tables[0].Rows.Count ==1)
				{
										if( ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
						this.ACEPCAO = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

					if( ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
						this.PALAVRAS = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]);


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