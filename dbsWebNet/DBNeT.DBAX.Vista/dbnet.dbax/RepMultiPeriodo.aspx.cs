﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using DBNeT.DBAX.Controlador;
using DBNeT.Base.Modelo;
using DBNeT.Base.Controlador;


public partial class Website_spedsheet : System.Web.UI.Page
{
    #region Pagina Base
    private string _gsModo = string.Empty;
    private SessionWeb _goSessionWeb;

    private void RecuperaSessionWeb()
    {
        if (Session["sessionWeb"] == null)
        { Response.Redirect("~/dbnFw5/dbnLogin.aspx"); }
        else
        { _goSessionWeb = (SessionWeb)Session["sessionWeb"]; }
    }
    public void GuardaSessionWeb()
    { Session["sessionWeb"] = _goSessionWeb; }
    #endregion
    GeneracionExcel GenExcel = new GeneracionExcel();
    MantencionCntx Contextos = new MantencionCntx();
    GeneradorGrupo geneGru = new GeneradorGrupo();
    public string GrupoEmpr = "", SegmEmpr = "", TipoTaxonomia="";

    protected void Page_Load(object sender, EventArgs e)
    {
        this.RecuperaSessionWeb();
        lb_error.Visible = false;     
        if (!IsPostBack)
        {
            DataTable dt = geneGru.getGrupos().Tables[0];
            ddl_Grupo.DataSource = dt;
            ddl_Grupo.DataTextField = dt.Columns["desc_grup"].ToString();
            ddl_Grupo.DataValueField = dt.Columns["codi_grup"].ToString();
            ddl_Grupo.DataBind();

            dt = geneGru.getSegmentos().Tables[0];
            ddl_Segmento.DataSource = dt;
            ddl_Segmento.DataTextField = dt.Columns["desc_segm"].ToString();
            ddl_Segmento.DataValueField = dt.Columns["codi_segm"].ToString();
            ddl_Segmento.DataBind();

            dt = geneGru.getTiposTaxonomia().Tables[0];
            ddl_TipoTaxonomia.DataSource = dt;
            ddl_TipoTaxonomia.DataTextField = dt.Columns["desc_tipo"].ToString();
            ddl_TipoTaxonomia.DataValueField = dt.Columns["tipo_taxo"].ToString();
            ddl_TipoTaxonomia.DataBind();
            SysParamController _loSysaParam = new SysParamController();
            var loResultado = _loSysaParam.readParametro("S", 0, 0, null, "DBAX_DEFE_TAXO", null, null, null, null, _goSessionWeb.CODI_USUA, _goSessionWeb.CODI_EMPR, _goSessionWeb.CODI_EMEX);
            ddl_TipoTaxonomia.SelectedValue = loResultado.PARAM_VALUE;

            llenado_de_periodos();
            llenado_de_empresa();
            llenado_de_informes();
            llenado_de_moneda();
            //llenado_de_contextos();
        }
    }

    protected void llenado_de_contextos()
    {
        try
        {
            DataSet ds = Contextos.getContextos(_goSessionWeb.CODI_EMEX, _goSessionWeb.CODI_EMPR.ToString(), ddl_CodiInfo.SelectedValue);
            ddl_CodiCntx.DataSource = ds;
            ddl_CodiCntx.DataTextField = ds.Tables[0].Columns["codi_cntx"].ToString();
            ddl_CodiCntx.DataValueField = ds.Tables[0].Columns["codi_cntx"].ToString();
            ddl_CodiCntx.DataBind();
        }
        catch (Exception ex)
        {
            lb_error.Visible = true;
            lb_error.Text = ex.Message;
        }
    }
    protected void llenado_de_periodos()
    {
        try
        {
            DataTable dt = GenExcel.getPersCorrInst("");
            ddl_CorrInstIni.DataSource = dt;
            ddl_CorrInstIni.DataTextField = dt.Columns["desc_inst"].ToString();
            ddl_CorrInstIni.DataValueField = dt.Columns["corr_inst"].ToString();
            ddl_CorrInstIni.DataBind();

            dt = GenExcel.getPersCorrInst("", ddl_CorrInstIni.SelectedValue);
            ddl_CorrInstFin.DataSource = dt;
            ddl_CorrInstFin.DataTextField = dt.Columns["desc_inst"].ToString();
            ddl_CorrInstFin.DataValueField = dt.Columns["corr_inst"].ToString();
            ddl_CorrInstFin.DataBind();
        }
        catch (Exception ex)
        {
            lb_error.Visible = true;
            lb_error.Text = ex.Message;
        }
    }
    protected void llenado_de_informes()
    {
        try
        {
            DataTable ds = GenExcel.getInformes(_goSessionWeb.CODI_EMEX, _goSessionWeb.CODI_EMPR.ToString(), ddl_TipoTaxonomia.SelectedValue, "C").Tables[0];

            ddl_CodiInfo.DataSource = ds;
            ddl_CodiInfo.DataTextField = ds.Columns["desc_info"].ToString();
            ddl_CodiInfo.DataValueField = ds.Columns["codi_info"].ToString();
            ddl_CodiInfo.DataBind();

            llenado_de_contextos();
        }
        catch (Exception ex)
        {
            lb_error.Visible = true;
            lb_error.Text = ex.Message;
        }
    }
    protected void llenado_de_empresa()
    {
        try
        {
            DataSet ds = GenExcel.GetEmpresas(_goSessionWeb.CODI_EMEX, _goSessionWeb.CODI_EMPR.ToString(), "", Filtro_Empresa.Text, ddl_Grupo.SelectedValue.ToString(), ddl_Segmento.SelectedValue.ToString(), ddl_TipoTaxonomia.SelectedValue, "P");

            ddl_CodiEmpr.DataSource = ds;
            ddl_CodiEmpr.DataTextField = ds.Tables[0].Columns["desc_pers"].ToString();
            ddl_CodiEmpr.DataValueField = ds.Tables[0].Columns["codi_pers"].ToString();
            ddl_CodiEmpr.DataBind();

            //llenado_de_versiones();
        }
        catch (Exception ex)
        {
            lb_error.Visible = true;
            lb_error.Text = ex.Message;
        }
    }
    protected void llenado_de_informes_Dimension()
    {
        try
        {
            DataTable dt = GenExcel.getInformesDimension("","","");

            ddl_CodiInfo.DataSource = dt;
            ddl_CodiInfo.DataTextField = dt.Columns[1].ToString();
            ddl_CodiInfo.DataValueField = dt.Columns[0].ToString();
            ddl_CodiInfo.DataBind();
        }
        catch (Exception ex)
        {
            lb_error.Visible = true;
            lb_error.Text = ex.Message;
        }
    }
    protected void guardarArchivo(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Clear();
            Response.ContentType = "application/excel";
            Response.AddHeader("Content-Disposition", @"attachment; filename=  " + ddl_CodiInfo.SelectedValue + ".xls");
            Response.Write(HttpUtility.UrlDecode(tb_html.Text, Encoding.GetEncoding("utf-8")));
            //Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            lb_error.Visible = true;
            lb_error.Text = ex.Message;
        }
    }
    protected void Filtro_Empresa_TextChanged(object sender, EventArgs e)
    {
        llenado_de_empresa();
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        GeneracionExcel GenExcel = new GeneracionExcel();
        string gGrupoEmpr = "", gSegmEmpr = "";
        gGrupoEmpr = (string)HttpContext.Current.Session["grupoEmpr"];
        gSegmEmpr = (string)HttpContext.Current.Session["SegmEmpr"];
        DataTable dt = GenExcel.GetEmpresas("1", "1","", prefixText, gGrupoEmpr, gSegmEmpr, "", "P").Tables[0];
        string[] resultados = new string[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            resultados[i] = dt.Rows[i][1].ToString();
        }
        return resultados;
    }

    protected void ddl_VersInst_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenado_de_informes();
    }
    protected void rbl_tipoInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenado_de_informes();
    }
    protected void rbl_rbl_TipoRepo_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenado_de_informes();
    }
    protected void ddl_Dime_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void RowCreated(object sender, GridViewRowEventArgs e)
    {
        // only apply changes if its DataRow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // when mouse is over the row, save original color to new attribute, and change it to highlight yellow color
            e.Row.Attributes.Add("onmouseover",
          "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#CCCCCC'");

            // when mouse leaves the row, change the bg color to its original value   
            e.Row.Attributes.Add("onmouseout",
            "this.style.backgroundColor=this.originalstyle;");
        }
    }
    protected void ddl_Grupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrupoEmpr = ddl_Grupo.SelectedValue.ToString();
        Session["GrupoEmpr"] = GrupoEmpr;
        llenado_de_empresa();
        //llenado_de_periodos();
        //ib_Rescatar_Click(null, null);
    }
    protected void ddl_Segmento_SelectedIndexChanged(object sender, EventArgs e)
    {
        SegmEmpr = ddl_Segmento.SelectedValue.ToString();
        Session["SegmEmpr"] = SegmEmpr;
        llenado_de_empresa();
        //llenado_de_periodos();
        //ib_Rescatar_Click(null, null);
    }
    protected void ddl_CodiEmpr_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Procesar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MantencionParametros para = new MantencionParametros();
            string sRutaXML = @para.getPathWebb() + @"\librerias\sheets\" + ddl_CodiInfo.SelectedValue + "_" + ddl_CodiEmpr.SelectedValue + ".html";
            string sRutaXML2 = "..\\librerias\\sheets\\" + ddl_CodiInfo.SelectedValue + "_" + ddl_CodiEmpr.SelectedValue + ".html";
            ruta_html.Text = sRutaXML2;
            DataTable dt_DescConc = new DataTable();
            if(chkMoneOrig.Checked)
                dt_DescConc = GenExcel.getDatosReporte(_goSessionWeb.CODI_EMEX, _goSessionWeb.CODI_EMPR.ToString(), ddl_CorrInstIni.SelectedValue, ddl_CorrInstFin.SelectedValue, ddl_CodiCntx.SelectedValue, ddl_CodiInfo.SelectedValue,"C", ddl_CodiEmpr.SelectedValue, "MONE_ORIG");
            else
                dt_DescConc = GenExcel.getDatosReporte(_goSessionWeb.CODI_EMEX, _goSessionWeb.CODI_EMPR.ToString(), ddl_CorrInstIni.SelectedValue, ddl_CorrInstFin.SelectedValue, ddl_CodiCntx.SelectedValue, ddl_CodiInfo.SelectedValue,"C", ddl_CodiEmpr.SelectedValue, ddlTipoMone.SelectedValue);

            #region alerta por datos desactualizados
            DataTable dt_Periodos = GenExcel.getPeriodosEnRango(ddl_CorrInstIni.SelectedValue, ddl_CorrInstFin.SelectedValue);
            
            string vPeriodosDesactualizados = "";
            for (int i = 0; i < dt_Periodos.Rows.Count; i++)
            {
                DataTable dt = GenExcel.getEsUltimaVers(ddl_CodiEmpr.SelectedValue, dt_Periodos.Rows[i][0].ToString(), GenExcel.getUltPersVersInst(ddl_CodiEmpr.SelectedValue, dt_Periodos.Rows[i][0].ToString()));
                if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "0")
                {
                    vPeriodosDesactualizados += dt_Periodos.Rows[i][0].ToString() + ", ";
                }
            }

            if (vPeriodosDesactualizados.Length > 0) 
            {
                lb_error.Visible = true;
                lb_error.Text = "El(los) periodo(s) " + vPeriodosDesactualizados.Substring(0, vPeriodosDesactualizados.Length - 2) + " pueden estar desactualizados";
            }

            #endregion

            GenExcel.GeneradorHTML(sRutaXML, dt_DescConc, ddl_CodiInfo.SelectedValue);
        }
        catch (Exception ex)
        {
            lb_error.Visible = true;
            lb_error.Text = ex.Message;
        }
    }
    protected void ddl_CorrInstFin_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void ddl_CorrInstIni_SelectedIndexChanged(object sender, EventArgs e)
    {
            DataTable dt = GenExcel.getPersCorrInst("");

            dt = GenExcel.getPersCorrInst("",ddl_CorrInstIni.SelectedValue.ToString());
            ddl_CorrInstFin.DataSource = dt;
            ddl_CorrInstFin.DataTextField = dt.Columns["desc_inst"].ToString();
            ddl_CorrInstFin.DataValueField = dt.Columns["corr_inst"].ToString();
            ddl_CorrInstFin.DataBind();
    }
    protected void ddl_CodiInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenado_de_contextos();
        UpdatePanel2.Update();
    }
    protected void ddl_TipoTaxonomia_SelectedIndexChanged(object sender, EventArgs e)
    {
        TipoTaxonomia = ddl_TipoTaxonomia.SelectedValue;
        llenado_de_empresa();
        llenado_de_informes();
    }
    protected void llenado_de_moneda()
    {
        ParaEmprController _loParaEmpr = new ParaEmprController();
        DataTable dtParaEmpr = _loParaEmpr.readParaEmprDt("L", 1, 100, null, "mone", null, null, null, null, _goSessionWeb.CODI_USUA, _goSessionWeb.CODI_EMPR, _goSessionWeb.CODI_EMEX);
        this.ddlTipoMone.Items.Clear();
        foreach (DataRow item in dtParaEmpr.Rows)
        {
            this.ddlTipoMone.Items.Add(new ListItem(item["desc_paem"].ToString() + " (" + item["valo_paem"].ToString() + ")", item["codi_paem"].ToString()));
        }
        this.ddlTipoMone.DataBind();
        var loResu = _loParaEmpr.readParaEmpr("S", 0, 0, null, "ALL", "MONE_LOCA", null, null, null, _goSessionWeb.CODI_USUA, _goSessionWeb.CODI_EMPR, _goSessionWeb.CODI_EMEX);
        Helper.ddlSelecciona(ddlTipoMone, loResu.CODI_PAEM);
    }
    protected void chkMoneOrig_CheckedChanged(object sender, EventArgs e)
    {
        if (chkMoneOrig.Checked)
        {
            ddlTipoMone.Enabled = false;
            ddlTipoMone.Visible = false;

        }
        else
        {
            ddlTipoMone.Enabled = true;
            ddlTipoMone.Visible = true;
        }
    }
}