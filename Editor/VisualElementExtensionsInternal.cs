using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditorInternal;
using UnityEngine.UIElements;

namespace Kogane
{
    public static class VisualElementExtensionsInternal
    {
        private static readonly MethodInfo m_findElementsRecursiveMethod;

        static VisualElementExtensionsInternal()
        {
            var engineAssemblyPath          = InternalEditorUtility.GetEngineAssemblyPath();
            var engineAssemblyDirectoryName = Path.GetDirectoryName( engineAssemblyPath ).Replace( "\\", "/" );
            var assembly                    = Assembly.LoadFile( $@"{engineAssemblyDirectoryName}/UnityEditor.UIBuilderModule.dll" );
            var type                        = assembly.GetType( "Unity.UI.Builder.VisualElementExtensions" );

            m_findElementsRecursiveMethod = type.GetMethod( "FindElementsRecursive", BindingFlags.Static | BindingFlags.NonPublic );
        }

        public static VisualElement FindElement
        (
            this VisualElement        element,
            Func<VisualElement, bool> predicate
        )
        {
            var selected = new List<VisualElement>();
            m_findElementsRecursiveMethod.Invoke( null, new object[] { element, predicate, selected } );
            return selected.Count == 0 ? null : selected[ 0 ];
        }
    }
}