using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBNeT.DBAX.Modelo.BE;
using DBNeT.DBAX.Modelo.DAC;

namespace DBNeT.DBAX.Controlador
{
    public class DbaxDefiConcController
    {
        DbaxDefiConcDAC _goDbaxDefiConcDAC;
        public DbaxDefiConcController()
        { _goDbaxDefiConcDAC = new DbaxDefiConcDAC(); }

        /// <summary>
        /// Metodo para Insertar Registros en el Procedimiento Almacenado S_I_dbax_defi_conc
        /// </summary>
        /// <param name="toDbaxDefiConcBE"></param>
        public void createDbaxDefiConc(DbaxDefiConcBE toDbaxDefiConcBE)
        {
            _goDbaxDefiConcDAC.createDbaxDefiConc(toDbaxDefiConcBE);
        }

        /// <summary>
        /// Método para Obtener Los registros de la tabla dbax_defi_conc, si se va a realizar un select para Mantenedor
        /// </summary>
        /// <param name="tnTipo">Tipo de Select S Select Mantenedor  L Listador  LV Lista de Valores</param>
        /// <param name="pnPagina">Página a Obtener</param>
        /// <param name="pnRegPag">Número de Registros por Páginas</param>
        /// <param name="psCondicion">SQL Dinámico</param>
        /// <param name="psPar1">Parámetro 1 ó P_PARAM_NAME</param>
        /// <param name="psPar2">Parámetro 2</param>
        /// <param name="psPar3">Parámetro 3</param>
        /// <param name="psPar4">Parámetro 4</param>
        /// <param name="psPar5">Parámetro 5</param>
        /// <param name="ts_codi_usua">Usuario</param>
        /// <param name="tn_codi_empr">Empresa</param>
        /// <param name="ts_codi_emex">Holding</param>
        /// <returns></returns>
        public List<DbaxDefiConcBE> readDbaxDefiConcList(string tsTipo, int tnPagina, int tnRegPag, string tsCondicion, string tsPar1, string tsPar2, string tsPar3, string tsPar4, string tsPar5, string ts_codi_usua, int tn_codi_empr, string ts_codi_emex)
        {
            return _goDbaxDefiConcDAC.readDbaxDefiConcList(tsTipo, tnPagina, tnRegPag, tsCondicion, tsPar1, tsPar2, tsPar3, tsPar4, tsPar5, ts_codi_usua, tn_codi_empr, ts_codi_emex);
        }

        /// <summary>
        /// Metodo para obtener 1 Registro desde la Base de Datos de la Tabla dbax_defi_conc
        /// </summary>
        /// <param name="psTipo">S = para 1 Registro</param>
        /// <param name="pnPagina">0</param>
        /// <param name="pnRegPag">0</param>
        /// <param name="psCondicion">Codigo Concepto</param>
        /// <param name="psPar1">PARAM_NAME</param>
        /// <param name="psPar2">Prefijo</param>
        /// <param name="psPar3">NULL</param>
        /// <param name="psPar4">NULL</param>
        /// <param name="psPar5">NULL</param>
        /// <param name="ts_codi_usua">Usuario</param>
        /// <param name="tn_codi_empr">Empresa</param>
        /// <param name="ts_codi_emex">Holding</param>
        /// <returns></returns>
        public DbaxDefiConcBE readDbaxDefiConc(string tsTipo, int tnPagina, int tnRegPag, string tsCondicion, string tsPar1, string tsPar2, string tsPar3, string tsPar4, string tsPar5, string ts_codi_usua, int tn_codi_empr, string ts_codi_emex)
        {
            return _goDbaxDefiConcDAC.readDbaxDefiConc(tsTipo, tnPagina, tnRegPag, tsCondicion, tsPar1, tsPar2, tsPar3, tsPar4, tsPar5, ts_codi_usua, tn_codi_empr, ts_codi_emex);
        }

        /// <summary>
        /// Metodo para Actualizar los Datos de la Tabla dbax_defi_conc, todos los parametros se asignan a traves de las BE
        /// </summary>
        /// <param name="toDbaxDefiConcBE"></param>
        public void updateDbaxDefiConc(DbaxDefiConcBE toDbaxDefiConcBE)
        {
            _goDbaxDefiConcDAC.updateDbaxDefiConc(toDbaxDefiConcBE);
        }

        /// <summary>
        /// Método para Eliminar 1 Registro de la tabla dbax_defi_conc
        /// <param name="tsCodiConc"></param>
        /// <param name="tsPrefConc"></param>
        /// </summary>
        public void deleteDbaxDefiConc(string tsCodiConc, string tsPrefConc)
        {
            _goDbaxDefiConcDAC.deleteDbaxDefiConc(tsCodiConc, tsPrefConc);
        }
    }
}