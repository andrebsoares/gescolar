using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GEscolar.UI.Web.Utils
{
    public class BaseController : Controller
    {
        private void Success(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Success, message, dismissable);
        }

        private void Information(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Information, message, dismissable);
        }

        private void Warning(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Warning, message, dismissable);
        }

        private void Danger(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Danger, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[Alert.TempDataKey] = alerts;
        }

        public void ExibeMensagem(char tpMsg, int codMsg, bool dismissable = true)
        {
            TratamentoMensagem trataMsg = new TratamentoMensagem();
            string msg = trataMsg.ExibeMensagem(codMsg);

            if (tpMsg == 'S')
            {
                Success(msg, dismissable);
            }
            else if (tpMsg == 'I')
            {
                Information(msg, dismissable);
            }
            else if (tpMsg == 'W')
            {
                Warning(msg, dismissable);
            }
            else if (tpMsg == 'D')
            {
                Danger(msg, dismissable);
            }
        }
    }
}