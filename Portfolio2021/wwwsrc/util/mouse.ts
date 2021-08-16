export function getCenterOffset({ offsetLeft, offsetTop, offsetWidth, offsetHeight }: HTMLElement, x: number, y: number) {
    const centerOffsetX = (offsetLeft + offsetWidth / 2) - x;
    const centerOffsetY = (offsetTop + offsetHeight / 2) - y;
    
    return {
        x: centerOffsetX,
        y: centerOffsetY,
        percentX() {
            const half = offsetWidth  / 2
            return 1 - (half - centerOffsetX) / half
        },
        percentY() {
            const half = offsetHeight / 2
            return 1 - (half - centerOffsetY) / half
        }
    }
}