using SecondFloor.Model.Rules.Specifications;

namespace SecondFloor.Model.Rules
{
    public static class UsuarioServices
    {
        public static bool IsValid(this Usuario usuario)
        {
            UsuarioSpecification.Validade(usuario);

            return usuario.BrokenRules.Count == 0;
        }
    }
}