using System;
using System.Reflection;

namespace _037_YapilacaklarWebApiBilgeAdam.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}