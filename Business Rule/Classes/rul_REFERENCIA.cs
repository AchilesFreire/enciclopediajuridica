using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;


namespace EnciclopediaJuridica.BusinessRule
{
    public class rul_REFERENCIA
    {

        #region "Variaveis"

        private int _REFERENCIA = -1;
        private int _VERBETEORIGEM = -1;
        private int _VERBETEDESTINO = -1;


        private String _mensagem = "";
        private Boolean _NovoRegistro = true;

        #endregion

        #region "Construtures"

        public rul_REFERENCIA()
        {
        }
        public rul_REFERENCIA(int par_REFERENCIA)
        {
            try
            {
                this.REFERENCIA = par_REFERENCIA;

                this.NovoRegistro = !this.Load();
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }

        }

        #endregion

        #region "Propriedades"

        public int REFERENCIA
        {
            get { return _REFERENCIA; }
            set { _REFERENCIA = value; }
        }

        public int VERBETEORIGEM
        {
            get { return _VERBETEORIGEM; }
            set { _VERBETEORIGEM = value; }
        }

        public int VERBETEDESTINO
        {
            get { return _VERBETEDESTINO; }
            set { _VERBETEDESTINO = value; }
        }





        public String mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }

        public Boolean NovoRegistro
        {
            get { return _NovoRegistro; }
            set { _NovoRegistro = value; }
        }

        #endregion

        #region "Metodos Publicos"

        public Boolean ValidateInsert()
        {
            try
            {
                // Validacao para o insert e o update
                if (!Validate())
                    return false;

                //
                // TODO: Adicionar regras de validacao aqui
                //
                cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();

                REFERENCIA.REFERENCIA = this.REFERENCIA;
                REFERENCIA.VERBETEORIGEM = this.VERBETEORIGEM;
                REFERENCIA.VERBETEDESTINO = this.VERBETEDESTINO;

                this.mensagem = "";

                Boolean retorno = REFERENCIA.Insert();

                this.mensagem = REFERENCIA.mensagem;

                return retorno;
            }
            catch (Exception ex)
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
                if (!Validate())
                    return false;

                //
                // TODO: Adicionar regras de validacao aqui
                //
                cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();

                REFERENCIA.REFERENCIA = this.REFERENCIA;
                REFERENCIA.VERBETEORIGEM = this.VERBETEORIGEM;
                REFERENCIA.VERBETEDESTINO = this.VERBETEDESTINO;

                this.mensagem = "";

                Boolean retorno = REFERENCIA.Update();

                this.mensagem = REFERENCIA.mensagem;

                return retorno;
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return false;
            }
        }

        public Boolean Validate()
        {
            try
            {

                if (this.VERBETEORIGEM == -1)
                {
                    this.mensagem = "O Campo VERBETEORIGEM tem que ser preenchido com Inteiro";
                    return false;
                }
                if (this.VERBETEDESTINO == -1)
                {
                    this.mensagem = "O Campo VERBETEDESTINO tem que ser preenchido com Inteiro";
                    return false;
                }


                return true;
            }
            catch (Exception ex)
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
                cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();


                REFERENCIA.REFERENCIA = this.REFERENCIA;
                REFERENCIA.VERBETEORIGEM = this.VERBETEORIGEM;
                REFERENCIA.VERBETEDESTINO = this.VERBETEDESTINO;


                if (VerifyForeignKeys())
                {

                    this.mensagem = "";

                    Boolean retorno = REFERENCIA.Delete();

                    this.mensagem = REFERENCIA.mensagem;

                    return retorno;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
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
                cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();


                this.mensagem = "";

                Boolean retorno = REFERENCIA.DeleteMasterDetail();

                this.mensagem = REFERENCIA.mensagem;

                return retorno;

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return false;
            }
        }

        public col_REFERENCIA GetAll()
        {
            try
            {
                cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();
                col_REFERENCIA colecao = new col_REFERENCIA();

                REFERENCIA.REFERENCIA = this.REFERENCIA;
                REFERENCIA.VERBETEORIGEM = this.VERBETEORIGEM;
                REFERENCIA.VERBETEDESTINO = this.VERBETEDESTINO;

                System.Data.DataSet ds = REFERENCIA.GetAll();

                if (REFERENCIA.mensagem != String.Empty)
                {
                    this.mensagem = REFERENCIA.mensagem;
                    return null;
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    rul_REFERENCIA item = new rul_REFERENCIA();
                    if (ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
                        item.REFERENCIA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

                    if (ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
                        item.VERBETEORIGEM = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

                    if (ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
                        item.VERBETEDESTINO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2]);


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
                cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();

                REFERENCIA.REFERENCIA = this.REFERENCIA;
                REFERENCIA.VERBETEORIGEM = this.VERBETEORIGEM;
                REFERENCIA.VERBETEDESTINO = this.VERBETEDESTINO;

                System.Data.DataSet ds = REFERENCIA.GetAll();

                this.mensagem = REFERENCIA.mensagem;

                return ds;
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return null;
            }
        }

        public col_REFERENCIA FindAll()
        {

            cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();
            col_REFERENCIA colecao = new col_REFERENCIA();

            REFERENCIA.REFERENCIA = this.REFERENCIA;
            REFERENCIA.VERBETEORIGEM = this.VERBETEORIGEM;
            REFERENCIA.VERBETEDESTINO = this.VERBETEDESTINO;

            System.Data.DataSet ds = REFERENCIA.FindAll();

            if (REFERENCIA.mensagem != String.Empty)
            {
                this.mensagem = REFERENCIA.mensagem;
                return null;
            }


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                rul_REFERENCIA item = new rul_REFERENCIA();
                if (ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
                    item.REFERENCIA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

                if (ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
                    item.VERBETEORIGEM = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

                if (ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
                    item.VERBETEDESTINO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2]);


                item.NovoRegistro = false;
                colecao.Add(item);
            }

            return colecao;

        }

        public col_REFERENCIA FindAllGrid()
        {

            cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();
            col_REFERENCIA colecao = new col_REFERENCIA();

            REFERENCIA.REFERENCIA = this.REFERENCIA;
            REFERENCIA.VERBETEORIGEM = this.VERBETEORIGEM;
            REFERENCIA.VERBETEDESTINO = this.VERBETEDESTINO;

            System.Data.DataSet ds = REFERENCIA.FindAllGrid();

            if (REFERENCIA.mensagem != String.Empty)
            {
                this.mensagem = REFERENCIA.mensagem;
                return null;
            }


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                rul_REFERENCIA item = new rul_REFERENCIA();
                if (ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
                    item.REFERENCIA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

                if (ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
                    item.VERBETEORIGEM = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1]);

                if (ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
                    item.VERBETEDESTINO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2]);


                item.NovoRegistro = false;
                colecao.Add(item);
            }

            return colecao;

        }

        public System.Data.DataSet RetornaReferencias()
        {
            try
            {
                cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();

                REFERENCIA.REFERENCIA = this.REFERENCIA;
                REFERENCIA.VERBETEORIGEM = this.VERBETEORIGEM;
                REFERENCIA.VERBETEDESTINO = this.VERBETEDESTINO;

                System.Data.DataSet ds = REFERENCIA.RetornaReferencias();

                this.mensagem = REFERENCIA.mensagem;

                return ds;
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return null;
            }
        }




        public System.Data.DataSet FindAllInDataSet()
        {
            try
            {
                cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();

                REFERENCIA.REFERENCIA = this.REFERENCIA;
                REFERENCIA.VERBETEORIGEM = this.VERBETEORIGEM;
                REFERENCIA.VERBETEDESTINO = this.VERBETEDESTINO;

                System.Data.DataSet ds = REFERENCIA.FindAll();

                this.mensagem = REFERENCIA.mensagem;

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
                cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();


                System.Data.DataSet ds = REFERENCIA.GetAllMasterDetail();

                this.mensagem = REFERENCIA.mensagem;

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
                cls_REFERENCIA REFERENCIA = new cls_REFERENCIA();



                REFERENCIA.REFERENCIA = this.REFERENCIA;


                System.Data.DataSet ds = REFERENCIA.Load();


                if (REFERENCIA.mensagem != String.Empty)
                {
                    this.mensagem = REFERENCIA.mensagem;
                    return false;
                }


                if (ds.Tables[0].Rows.Count == 1)
                {
                    if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
                        this.REFERENCIA = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

                    if (ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
                        this.VERBETEORIGEM = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[1]);

                    if (ds.Tables[0].Rows[0].ItemArray[2].ToString() != String.Empty)
                        this.VERBETEDESTINO = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[2]);


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
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return false;
            }
        }

        #endregion
    }
}