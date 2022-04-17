import { defineConfig } from 'vite';

export default defineConfig({
    base: "./",
    root: "public",
    build: {
        outdir: "../public",
        emptyOutDir: true,
        sourcemap: false,
    }
})