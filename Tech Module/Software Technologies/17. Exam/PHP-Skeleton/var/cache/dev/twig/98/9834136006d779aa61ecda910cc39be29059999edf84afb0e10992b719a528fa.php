<?php

/* @WebProfiler/Collector/router.html.twig */
class __TwigTemplate_09886c37796d81d574b2448cf2a22ea32da8dad546b69f22c376ce19a869ce97 extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("@WebProfiler/Profiler/layout.html.twig", "@WebProfiler/Collector/router.html.twig", 1);
        $this->blocks = array(
            'toolbar' => array($this, 'block_toolbar'),
            'menu' => array($this, 'block_menu'),
            'panel' => array($this, 'block_panel'),
        );
    }

    protected function doGetParent(array $context)
    {
        return "@WebProfiler/Profiler/layout.html.twig";
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_662f77597767d0a9d0cbe503f96a70095492b2df050b038f7b28f49d4054ebe5 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_662f77597767d0a9d0cbe503f96a70095492b2df050b038f7b28f49d4054ebe5->enter($__internal_662f77597767d0a9d0cbe503f96a70095492b2df050b038f7b28f49d4054ebe5_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@WebProfiler/Collector/router.html.twig"));

        $__internal_f3c50f619880d3fa2e18bb6e545dc736e8b387b7be97bbda1bb0ef8e9cb99b96 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_f3c50f619880d3fa2e18bb6e545dc736e8b387b7be97bbda1bb0ef8e9cb99b96->enter($__internal_f3c50f619880d3fa2e18bb6e545dc736e8b387b7be97bbda1bb0ef8e9cb99b96_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@WebProfiler/Collector/router.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_662f77597767d0a9d0cbe503f96a70095492b2df050b038f7b28f49d4054ebe5->leave($__internal_662f77597767d0a9d0cbe503f96a70095492b2df050b038f7b28f49d4054ebe5_prof);

        
        $__internal_f3c50f619880d3fa2e18bb6e545dc736e8b387b7be97bbda1bb0ef8e9cb99b96->leave($__internal_f3c50f619880d3fa2e18bb6e545dc736e8b387b7be97bbda1bb0ef8e9cb99b96_prof);

    }

    // line 3
    public function block_toolbar($context, array $blocks = array())
    {
        $__internal_b59b0c9bdd358f09da99ec47c8474f390a93b4974759f1ae5411d32b520978c5 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_b59b0c9bdd358f09da99ec47c8474f390a93b4974759f1ae5411d32b520978c5->enter($__internal_b59b0c9bdd358f09da99ec47c8474f390a93b4974759f1ae5411d32b520978c5_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "toolbar"));

        $__internal_062a8b8e1f9547adb1e09e0c80411ff4221a5fa17f4f3cdc5e66e52e33b2b502 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_062a8b8e1f9547adb1e09e0c80411ff4221a5fa17f4f3cdc5e66e52e33b2b502->enter($__internal_062a8b8e1f9547adb1e09e0c80411ff4221a5fa17f4f3cdc5e66e52e33b2b502_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "toolbar"));

        
        $__internal_062a8b8e1f9547adb1e09e0c80411ff4221a5fa17f4f3cdc5e66e52e33b2b502->leave($__internal_062a8b8e1f9547adb1e09e0c80411ff4221a5fa17f4f3cdc5e66e52e33b2b502_prof);

        
        $__internal_b59b0c9bdd358f09da99ec47c8474f390a93b4974759f1ae5411d32b520978c5->leave($__internal_b59b0c9bdd358f09da99ec47c8474f390a93b4974759f1ae5411d32b520978c5_prof);

    }

    // line 5
    public function block_menu($context, array $blocks = array())
    {
        $__internal_d7749758af09caf6c97cb456f52424ebb511d17c22e0b85adee1144ebfd56fa6 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_d7749758af09caf6c97cb456f52424ebb511d17c22e0b85adee1144ebfd56fa6->enter($__internal_d7749758af09caf6c97cb456f52424ebb511d17c22e0b85adee1144ebfd56fa6_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "menu"));

        $__internal_47b94b13ddc8fed555cc955abb177e931e0cc662ef994c180dc788886aa6291d = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_47b94b13ddc8fed555cc955abb177e931e0cc662ef994c180dc788886aa6291d->enter($__internal_47b94b13ddc8fed555cc955abb177e931e0cc662ef994c180dc788886aa6291d_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "menu"));

        // line 6
        echo "<span class=\"label\">
    <span class=\"icon\">";
        // line 7
        echo twig_include($this->env, $context, "@WebProfiler/Icon/router.svg");
        echo "</span>
    <strong>Routing</strong>
</span>
";
        
        $__internal_47b94b13ddc8fed555cc955abb177e931e0cc662ef994c180dc788886aa6291d->leave($__internal_47b94b13ddc8fed555cc955abb177e931e0cc662ef994c180dc788886aa6291d_prof);

        
        $__internal_d7749758af09caf6c97cb456f52424ebb511d17c22e0b85adee1144ebfd56fa6->leave($__internal_d7749758af09caf6c97cb456f52424ebb511d17c22e0b85adee1144ebfd56fa6_prof);

    }

    // line 12
    public function block_panel($context, array $blocks = array())
    {
        $__internal_07b26aa4e1f6cdfdf74c1211cd28ed879a9c784d54064c312da00369595a2a3d = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_07b26aa4e1f6cdfdf74c1211cd28ed879a9c784d54064c312da00369595a2a3d->enter($__internal_07b26aa4e1f6cdfdf74c1211cd28ed879a9c784d54064c312da00369595a2a3d_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "panel"));

        $__internal_b3bdecdd3101dd8e6b3e70a608052a6e1864fa4c2f1b972b4110b0bbe414c0d6 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_b3bdecdd3101dd8e6b3e70a608052a6e1864fa4c2f1b972b4110b0bbe414c0d6->enter($__internal_b3bdecdd3101dd8e6b3e70a608052a6e1864fa4c2f1b972b4110b0bbe414c0d6_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "panel"));

        // line 13
        echo "    ";
        echo $this->env->getRuntime('Symfony\Bridge\Twig\Extension\HttpKernelRuntime')->renderFragment($this->env->getExtension('Symfony\Bridge\Twig\Extension\RoutingExtension')->getPath("_profiler_router", array("token" => ($context["token"] ?? $this->getContext($context, "token")))));
        echo "
";
        
        $__internal_b3bdecdd3101dd8e6b3e70a608052a6e1864fa4c2f1b972b4110b0bbe414c0d6->leave($__internal_b3bdecdd3101dd8e6b3e70a608052a6e1864fa4c2f1b972b4110b0bbe414c0d6_prof);

        
        $__internal_07b26aa4e1f6cdfdf74c1211cd28ed879a9c784d54064c312da00369595a2a3d->leave($__internal_07b26aa4e1f6cdfdf74c1211cd28ed879a9c784d54064c312da00369595a2a3d_prof);

    }

    public function getTemplateName()
    {
        return "@WebProfiler/Collector/router.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  94 => 13,  85 => 12,  71 => 7,  68 => 6,  59 => 5,  42 => 3,  11 => 1,);
    }

    /** @deprecated since 1.27 (to be removed in 2.0). Use getSourceContext() instead */
    public function getSource()
    {
        @trigger_error('The '.__METHOD__.' method is deprecated since version 1.27 and will be removed in 2.0. Use getSourceContext() instead.', E_USER_DEPRECATED);

        return $this->getSourceContext()->getCode();
    }

    public function getSourceContext()
    {
        return new Twig_Source("{% extends '@WebProfiler/Profiler/layout.html.twig' %}

{% block toolbar %}{% endblock %}

{% block menu %}
<span class=\"label\">
    <span class=\"icon\">{{ include('@WebProfiler/Icon/router.svg') }}</span>
    <strong>Routing</strong>
</span>
{% endblock %}

{% block panel %}
    {{ render(path('_profiler_router', { token: token })) }}
{% endblock %}
", "@WebProfiler/Collector/router.html.twig", "C:\\Users\\doba7a\\Desktop\\ex\\PHP-Skeleton\\vendor\\symfony\\symfony\\src\\Symfony\\Bundle\\WebProfilerBundle\\Resources\\views\\Collector\\router.html.twig");
    }
}
