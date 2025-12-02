import {defineConfig} from 'vite';
{%- if cookiecutter.ui_library == 'Tailwind' %}
import tailwindcss from '@tailwindcss/vite';
{%- endif %}

export default defineConfig({
    appType: 'custom',
    base: '/dist/',
    publicDir: false,
{%- if cookiecutter.ui_library == 'Tailwind' %}
    plugins: [
        tailwindcss()
    ],
{%- endif %}
    build: {
        manifest: true,
        emptyOutDir: true,
        outDir: 'wwwroot/dist',
        rollupOptions: {
            input: [
                "Assets/js/vendor.js",
                "Assets/js/app.js"
            ],
        }
    }
});