function solve(args) {
    let input = args[0];
    let sites = input.match(/>.*<\/a>/g);
    console.log(sites);
}
solve(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);
