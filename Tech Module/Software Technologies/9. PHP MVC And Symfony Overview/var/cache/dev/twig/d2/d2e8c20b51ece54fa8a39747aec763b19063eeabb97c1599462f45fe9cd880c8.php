<?php

/* @WebProfiler/Collector/router.html.twig */
class __TwigTemplate_b39d2deec5bf97db869eaa7b3037f1db85fd4cf799ea0623fb1360a78fcaf680 extends Twig_Template
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
        $__internal_f270dabc81e03db614b87e33f539149f420b2aa3362c943137ebeee2cda59bc0 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_f270dabc81e03db614b87e33f539149f420b2aa3362c943137ebeee2cda59bc0->enter($__internal_f270dabc81e03db614b87e33f539149f420b2aa3362c943137ebeee2cda59bc0_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@WebProfiler/Collector/router.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_f270dabc81e03db614b87e33f539149f420b2aa3362c943137ebeee2cda59bc0->leave($__internal_f270dabc81e03db614b87e33f539149f420b2aa3362c943137ebeee2cda59bc0_prof);

    }

    // line 3
    public function block_toolbar($context, array $blocks = array())
    {
        $__internal_f2b4cc1a082dc22c3c12ff5d11af1e7078fd3f4959be20b0affe279266cb8d38 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_f2b4cc1a082dc22c3c12ff5d11af1e7078fd3f4959be20b0affe279266cb8d38->enter($__internal_f2b4cc1a082dc22c3c12ff5d11af1e7078fd3f4959be20b0affe279266cb8d38_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "toolbar"));

        
        $__internal_f2b4cc1a082dc22c3c12ff5d11af1e7078fd3f4959be20b0affe279266cb8d38->leave($__internal_f2b4cc1a082dc22c3c12ff5d11af1e7078fd3f4959be20b0affe279266cb8d38_prof);

    }

    // line 5
    public function block_menu($context, array $blocks = array())
    {
        $__internal_c0c736957c79cbf22d3e90d81d061114d481c8064c5edcb1ee3caab6931e5e0f = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_c0c736957c79cbf22d3e90d81d061114d481c8064c5edcb1ee3caab6931e5e0f->enter($__internal_c0c736957c79cbf22d3e90d81d061114d481c8064c5edcb1ee3caab6931e5e0f_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "menu"));

        // line 6
        echo "<span class=\"label\">
    <span class=\"icon\">";
        // line 7
        echo twig_include($this->env, $context, "@WebProfiler/Icon/router.svg");
        echo "</span>
    <strong>Routing</strong>
</span>
";
        
        $__internal_c0c736957c79cbf22d3e90d81d061114d481c8064c5edcb1ee3caab6931e5e0f->leave($__internal_c0c736957c79cbf22d3e90d81d061114d481c8064c5edcb1ee3caab6931e5e0f_prof);

    }

    // line 12
    public function block_panel($context, array $blocks = array())
    {
        $__internal_10acdb860ba8862e016d8b4be1bd28647d4a86251a1c22ee3d1e122b3df2deb5 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_10acdb860ba8862e016d8b4be1bd28647d4a86251a1c22ee3d1e122b3df2deb5->enter($__internal_10acdb860ba8862e016d8b4be1bd28647d4a86251a1c22ee3d1e122b3df2deb5_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "panel"));

        // line 13
        echo "    ";
        echo $this->env->getExtension('Symfony\Bridge\Twig\Extension\HttpKernelExtension')->renderFragment($this->env->getExtension('Symfony\Bridge\Twig\Extension\RoutingExtension')->getPath("_profiler_router", array("token" => (isset($context["token"]) ? $context["token"] : $this->getContext($context, "token")))));
        echo "
";
        
        $__internal_10acdb860ba8862e016d8b4be1bd28647d4a86251a1c22ee3d1e122b3df2deb5->leave($__internal_10acdb860ba8862e016d8b4be1bd28647d4a86251a1c22ee3d1e122b3df2deb5_prof);

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
        return array (  73 => 13,  67 => 12,  56 => 7,  53 => 6,  47 => 5,  36 => 3,  11 => 1,);
    }

    public function getSource()
    {
        return "{% extends '@WebProfiler/Profiler/layout.html.twig' %}

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
";
    }
}
