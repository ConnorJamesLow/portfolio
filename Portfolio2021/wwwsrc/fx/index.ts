import { debounce } from "../util/main";
import { getCenterOffset } from "../util/mouse";

/**
 * Apply a rotation effect based on the mouse position over an element.
 * @param element The element to rotate on hover
 * @param max The max rotation degree
 */
export function rotate3d(element: HTMLElement, max: number): void
export function rotate3d(element: HTMLElement, xMax: number, yMax: number): void
export function rotate3d(element: HTMLElement, xMax: number, yMax?: number): void {
    if (yMax === undefined) {
        yMax = xMax;
    }
    console.log('rotating:', element, yMax, xMax)
    element.addEventListener('mouseleave', debounce(() => {
        element.style.transform = '';
    }, 20));

    element.addEventListener('mousemove', debounce(e => {
        const center = getCenterOffset(element, e.x, e.y);
        element.style.transform = `rotateY(${center.percentX() * xMax}deg) rotateX(${center.percentY() * yMax!}deg)`
    }, 10))
}