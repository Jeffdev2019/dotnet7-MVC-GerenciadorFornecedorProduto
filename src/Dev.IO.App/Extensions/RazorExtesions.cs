using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dev.IO.App.Extensions
{
    public static class RazorExtesions
    {
        public static string FormataDocumento(this RazorPage page, int tipoPessoa, string documento) =>
            tipoPessoa == 1 ?
                Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00")
            :
                Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
    }
}
