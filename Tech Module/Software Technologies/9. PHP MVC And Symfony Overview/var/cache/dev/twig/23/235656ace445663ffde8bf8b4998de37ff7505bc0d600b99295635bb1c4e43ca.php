<?php

/* @Twig/Exception/exception_full.html.twig */
class __TwigTemplate_74c889c78b86a0e0b9d5e4bc40f88b3ee07a078ebe65a366ad3853d03d09c149 extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("@Twig/layout.html.twig", "@Twig/Exception/exception_full.html.twig", 1);
        $this->blocks = array(
            'head' => array($this, 'block_head'),
            'title' => array($this, 'block_title'),
            'body' => array($this, 'block_body'),
        );
    }

    protected function doGetParent(array $context)
    {
        return "@Twig/layout.html.twig";
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_e7bc4d31c404032543219b80ed9dcb5c916e149293585d5a3a32e8ddf593a151 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_e7bc4d31c404032543219b80ed9dcb5c916e149293585d5a3a32e8ddf593a151->enter($__internal_e7bc4d31c404032543219b80ed9dcb5c916e149293585d5a3a32e8ddf593a151_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@Twig/Exception/exception_full.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_e7bc4d31c404032543219b80ed9dcb5c916e149293585d5a3a32e8ddf593a151->leave($__internal_e7bc4d31c404032543219b80ed9dcb5c916e149293585d5a3a32e8ddf593a151_prof);

    }

    // line 3
    public function block_head($context, array $blocks = array())
    {
        $__internal_d660e12997c32ef5fc444bf61fb9f8bc9d4dc66e1b893dec8e6c397ec266d561 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_d660e12997c32ef5fc444bf61fb9f8bc9d4dc66e1b893dec8e6c397ec266d561->enter($__internal_d660e12997c32ef5fc444bf61fb9f8bc9d4dc66e1b893dec8e6c397ec266d561_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "head"));

        // line 4
        echo "    <link href=\"";
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\HttpFoundationExtension')->generateAbsoluteUrl($this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("bundles/framework/css/exception.css")), "html", null, true);
        echo "\" rel=\"stylesheet\" type=\"text/css\" media=\"all\" />
";
        
        $__internal_d660e12997c32ef5fc444bf61fb9f8bc9d4dc66e1b893dec8e6c397ec266d561->leave($__internal_d660e12997c32ef5fc444bf61fb9f8bc9d4dc66e1b893dec8e6c397ec266d561_prof);

    }

    // line 7
    public function block_title($context, array $blocks = array())
    {
        $__internal_93dd69e919f0a4d3bbaaff0620fb6e9ac07ed414883d6c7cc26dbdbaeec8aa8f = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_93dd69e919f0a4d3bbaaff0620fb6e9ac07ed414883d6c7cc26dbdbaeec8aa8f->enter($__internal_93dd69e919f0a4d3bbaaff0620fb6e9ac07ed414883d6c7cc26dbdbaeec8aa8f_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "title"));

        // line 8
        echo "    ";
        echo twig_escape_filter($this->env, $this->getAttribute((isset($context["exception"]) ? $context["exception"] : $this->getContext($context, "exception")), "message", array()), "html", null, true);
        echo " (";
        echo twig_escape_filter($this->env, (isset($context["status_code"]) ? $context["status_code"] : $this->getContext($context, "status_code")), "html", null, true);
        echo " ";
        echo twig_escape_filter($this->env, (isset($context["status_text"]) ? $context["status_text"] : $this->getContext($context, "status_text")), "html", null, true);
        echo ")
";
        
        $__internal_93dd69e919f0a4d3bbaaff0620fb6e9ac07ed414883d6c7cc26dbdbaeec8aa8f->leave($__internal_93dd69e919f0a4d3bbaaff0620fb6e9ac07ed414883d6c7cc26dbdbaeec8aa8f_prof);

    }

    // line 11
    public function block_body($context, array $blocks = array())
    {
        $__internal_ec0713ceb2c3dd54d590bd010414efb39a26fbf130b669a5e437df6ceadb5d10 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_ec0713ceb2c3dd54d590bd010414efb39a26fbf130b669a5e437df6ceadb5d10->enter($__internal_ec0713ceb2c3dd54d590bd010414efb39a26fbf130b669a5e437df6ceadb5d10_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body"));

        // line 12
        echo "    ";
        $this->loadTemplate("@Twig/Exception/exception.html.twig", "@Twig/Exception/exception_full.html.twig", 12)->display($context);
        
        $__internal_ec0713ceb2c3dd54d590bd010414efb39a26fbf130b669a5e437df6ceadb5d10->leave($__internal_ec0713ceb2c3dd54d590bd010414efb39a26fbf130b669a5e437df6ceadb5d10_prof);

    }

    public function getTemplateName()
    {
        return "@Twig/Exception/exception_full.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  78 => 12,  72 => 11,  58 => 8,  52 => 7,  42 => 4,  36 => 3,  11 => 1,);
    }

    public function getSource()
    {
        return "{% extends '@Twig/layout.html.twig' %}

{% block head %}
    <link href=\"{{ absolute_url(asset('bundles/framework/css/exception.css')) }}\" rel=\"stylesheet\" type=\"text/css\" media=\"all\" />
{% endblock %}

{% block title %}
    {{ exception.message }} ({{ status_code }} {{ status_text }})
{% endblock %}

{% block body %}
    {% include '@Twig/Exception/exception.html.twig' %}
{% endblock %}
";
    }
}
