﻿var prev;
function showCon(obj) {
    if (prev != null) {
        document.getElementById("con" + prev).style.display = "none";
        document.getElementById("m" + prev).className = "pa";
    }
    document.getElementById("con" + obj).style.display = "block";
    document.getElementById("m" + obj).className = "paA";
    prev = obj;
}