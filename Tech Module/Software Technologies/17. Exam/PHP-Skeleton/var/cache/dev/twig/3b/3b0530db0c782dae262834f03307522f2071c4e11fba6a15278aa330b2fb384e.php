<?php

/* @WebProfiler/Collector/exception.html.twig */
class __TwigTemplate_f32ad73c9bc804e7d7685ce925e27ce9c7daa98efc0b9a8c89227d7076a75563 extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("@WebProfiler/Profiler/layout.html.twig", "@WebProfiler/Collector/exception.html.twig", 1);
        $this->blocks = array(
            'head' => array($this, 'block_head'),
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
        $__internal_9955b009e8cfdd900b27af5937179f35b7a6676c39b2616fa4e660aa631e98fe = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_9955b009e8cfdd900b27af5937179f35b7a6676c39b2616fa4e660aa631e98fe->enter($__internal_9955b009e8cfdd900b27af5937179f35b7a6676c39b2616fa4e660aa631e98fe_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@WebProfiler/Collector/exception.html.twig"));

        $__internal_6e03c7015dcd1b8fd21ea72363f0915b08ad45cdb17594d26bd60a458da82708 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_6e03c7015dcd1b8fd21ea72363f0915b08ad45cdb17594d26bd60a458da82708->enter($__internal_6e03c7015dcd1b8fd21ea72363f0915b08ad45cdb17594d26bd60a458da82708_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@WebProfiler/Collector/exception.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_9955b009e8cfdd900b27af5937179f35b7a6676c39b2616fa4e660aa631e98fe->leave($__internal_9955b009e8cfdd900b27af5937179f35b7a6676c39b2616fa4e660aa631e98fe_prof);

        
        $__internal_6e03c7015dcd1b8fd21ea72363f0915b08ad45cdb17594d26bd60a458da82708->leave($__internal_6e03c7015dcd1b8fd21ea72363f0915b08ad45cdb17594d26bd60a458da82708_prof);

    }

    // line 3
    public function block_head($context, array $blocks = array())
    {
        $__internal_a89f0b46af04dcc76dd57baedf35d8ca4645e5aa20ea922a701be718c6866514 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_a89f0b46af04dcc76dd57baedf35d8ca4645e5aa20ea922a701be718c6866514->enter($__internal_a89f0b46af04dcc76dd57baedf35d8ca4645e5aa20ea922a701be718c6866514_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "head"));

        $__internal_50c29b489017ac6ac0c231cc3adf9e4e6e679c1ef0ce3b33c3438fec5145d3a7 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_50c29b489017ac6ac0c231cc3adf9e4e6e679c1ef0ce3b33c3438fec5145d3a7->enter($__internal_50c29b489017ac6ac0c231cc3adf9e4e6e679c1ef0ce3b33c3438fec5145d3a7_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "head"));

        // line 4
        echo "    ";
        if ($this->getAttribute(($context["collector"] ?? $this->getContext($context, "collector")), "hasexception", array())) {
            // line 5
            echo "        <style>
            ";
            // line 6
            echo $this->env->getRuntime('Symfony\Bridge\Twig\Extension\HttpKernelRuntime')->renderFragment($this->env->getExtension('Symfony\Bridge\Twig\Extension\RoutingExtension')->getPath("_profiler_exception_css", array("token" => ($context["token"] ?? $this->getContext($context, "token")))));
            echo "
        </style>
    ";
        }
        // line 9
        echo "    ";
        $this->displayParentBlock("head", $context, $blocks);
        echo "
";
        
        $__internal_50c29b489017ac6ac0c231cc3adf9e4e6e679c1ef0ce3b33c3438fec5145d3a7->leave($__internal_50c29b489017ac6ac0c231cc3adf9e4e6e679c1ef0ce3b33c3438fec5145d3a7_prof);

        
        $__internal_a89f0b46af04dcc76dd57baedf35d8ca4645e5aa20ea922a701be718c6866514->leave($__internal_a89f0b46af04dcc76dd57baedf35d8ca4645e5aa20ea922a701be718c6866514_prof);

    }

    // line 12
    public function block_menu($context, array $blocks = array())
    {
        $__internal_7e777a39ed5f19dbceac0e0fa01ab687bcc6bc45c362413bab7f224084897e34 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_7e777a39ed5f19dbceac0e0fa01ab687bcc6bc45c362413bab7f224084897e34->enter($__internal_7e777a39ed5f19dbceac0e0fa01ab687bcc6bc45c362413bab7f224084897e34_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "menu"));

        $__internal_87d767320f83a48c36efbdbb2f7ab67b569f30c32c9f80a35c90b7f8bcd21f99 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_87d767320f83a48c36efbdbb2f7ab67b569f30c32c9f80a35c90b7f8bcd21f99->enter($__internal_87d767320f83a48c36efbdbb2f7ab67b569f30c32c9f80a35c90b7f8bcd21f99_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "menu"));

        // line 13
        echo "    <span class=\"label ";
        echo (($this->getAttribute(($context["collector"] ?? $this->getContext($context, "collector")), "hasexception", array())) ? ("label-status-error") : ("disabled"));
        echo "\">
        <span class=\"icon\">";
        // line 14
        echo twig_include($this->env, $context, "@WebProfiler/Icon/exception.svg");
        echo "</span>
        <strong>Exception</strong>
        ";
        // line 16
        if ($this->getAttribute(($context["collector"] ?? $this->getContext($context, "collector")), "hasexception", array())) {
            // line 17
            echo "            <span class=\"count\">
                <span>1</span>
            </span>
        ";
        }
        // line 21
        echo "    </span>
";
        
        $__internal_87d767320f83a48c36efbdbb2f7ab67b569f30c32c9f80a35c90b7f8bcd21f99->leave($__internal_87d767320f83a48c36efbdbb2f7ab67b569f30c32c9f80a35c90b7f8bcd21f99_prof);

        
        $__internal_7e777a39ed5f19dbceac0e0fa01ab687bcc6bc45c362413bab7f224084897e34->leave($__internal_7e777a39ed5f19dbceac0e0fa01ab687bcc6bc45c362413bab7f224084897e34_prof);

    }

    // line 24
    public function block_panel($context, array $blocks = array())
    {
        $__internal_ad2c3b25a003b2b0868c25ec546c1ca087998a73d3a318776b36529dd44d9a68 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_ad2c3b25a003b2b0868c25ec546c1ca087998a73d3a318776b36529dd44d9a68->enter($__internal_ad2c3b25a003b2b0868c25ec546c1ca087998a73d3a318776b36529dd44d9a68_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "panel"));

        $__internal_c5c720bc02eae88929e8044bb1422877937524a0639c4cb6a6a93cd48f05ac1c = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_c5c720bc02eae88929e8044bb1422877937524a0639c4cb6a6a93cd48f05ac1c->enter($__internal_c5c720bc02eae88929e8044bb1422877937524a0639c4cb6a6a93cd48f05ac1c_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "panel"));

        // line 25
        echo "    <h2>Exceptions</h2>

    ";
        // line 27
        if ( !$this->getAttribute(($context["collector"] ?? $this->getContext($context, "collector")), "hasexception", array())) {
            // line 28
            echo "        <div class=\"empty\">
            <p>No exception was thrown and caught during the request.</p>
        </div>
    ";
        } else {
            // line 32
            echo "        <div class=\"sf-reset\">
            ";
            // line 33
            echo $this->env->getRuntime('Symfony\Bridge\Twig\Extension\HttpKernelRuntime')->renderFragment($this->env->getExtension('Symfony\Bridge\Twig\Extension\RoutingExtension')->getPath("_profiler_exception", array("token" => ($context["token"] ?? $this->getContext($context, "token")))));
            echo "
        </div>
    ";
        }
        
        $__internal_c5c720bc02eae88929e8044bb1422877937524a0639c4cb6a6a93cd48f05ac1c->leave($__internal_c5c720bc02eae88929e8044bb1422877937524a0639c4cb6a6a93cd48f05ac1c_prof);

        
        $__internal_ad2c3b25a003b2b0868c25ec546c1ca087998a73d3a318776b36529dd44d9a68->leave($__internal_ad2c3b25a003b2b0868c25ec546c1ca087998a73d3a318776b36529dd44d9a68_prof);

    }

    public function getTemplateName()
    {
        return "@WebProfiler/Collector/exception.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  138 => 33,  135 => 32,  129 => 28,  127 => 27,  123 => 25,  114 => 24,  103 => 21,  97 => 17,  95 => 16,  90 => 14,  85 => 13,  76 => 12,  63 => 9,  57 => 6,  54 => 5,  51 => 4,  42 => 3,  11 => 1,);
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

{% block head %}
    {% if collector.hasexception %}
        <style>
            {{ render(path('_profiler_exception_css', { token: token })) }}
        </style>
    {% endif %}
    {{ parent() }}
{% endblock %}

{% block menu %}
    <span class=\"label {{ collector.hasexception ? 'label-status-error' : 'disabled' }}\">
        <span class=\"icon\">{{ include('@WebProfiler/Icon/exception.svg') }}</span>
        <strong>Exception</strong>
        {% if collector.hasexception %}
            <span class=\"count\">
                <span>1</span>
            </span>
        {% endif %}
    </span>
{% endblock %}

{% block panel %}
    <h2>Exceptions</h2>

    {% if not collector.hasexception %}
        <div class=\"empty\">
            <p>No exception was thrown and caught during the request.</p>
        </div>
    {% else %}
        <div class=\"sf-reset\">
            {{ render(path('_profiler_exception', { token: token })) }}
        </div>
    {% endif %}
{% endblock %}
", "@WebProfiler/Collector/exception.html.twig", "C:\\Users\\doba7a\\Desktop\\ex\\PHP-Skeleton\\vendor\\symfony\\symfony\\src\\Symfony\\Bundle\\WebProfilerBundle\\Resources\\views\\Collector\\exception.html.twig");
    }
}
