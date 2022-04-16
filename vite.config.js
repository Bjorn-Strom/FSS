import { defineConfig } from 'vite';

export default defineConfig({
    root: "dist",
    build: {
        base: "/FSS/",
        outdir: "../public",
        emptyOutDir: true,
        sourcemap: false
    }
})